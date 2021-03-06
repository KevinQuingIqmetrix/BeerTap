﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BeerTapV2.ApiServices.ApiServiceInterface;
using BeerTapV2.DTO;
using BeerTapV2.Model;
using BeerTapV2.Repository;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;

namespace BeerTapV2.ApiServices
{
    public class KegApiService: IKegApiService
    {
        private readonly IBeerTapRepository _repo;

        public KegApiService(IBeerTapRepository repo)
        {
            _repo = repo;
        }

        public KegApiService()
        {
            _repo = new BeerTapRepository();
        }
        public Task<ResourceCreationResult<Keg, int>> CreateAsync(Keg resource, IRequestContext context, CancellationToken cancellation)
        {
            SetContextId(context);
            //TODO: update tap spec hypermedia links 
            ValidateResourceInput(resource, context);

            var tapId = context.UriParameters.GetByName<int>("TapId").EnsureValue();
            var officeId = context.UriParameters.GetByName<int>("OfficeId").EnsureValue();

            //validate flavor is same or not and threshold is reached or not
            var kegToBeReplaced = _repo.TapKegGet(tapId,officeId);
            if (kegToBeReplaced == null)
            {
                throw context.CreateHttpResponseException<Keg>("No Tap with Id specified in office", HttpStatusCode.NotFound);
            }
            var currentFlavor = kegToBeReplaced.Flavor;
            var currentIsBelowThreshold = ((kegToBeReplaced.Milliliters / kegToBeReplaced.Capacity) * 100) <
                                          kegToBeReplaced.ThresholdPercentage;
            var isRefillable = false;

            if (currentFlavor == resource.Flavor || string.IsNullOrWhiteSpace(resource.Flavor)) //if flavor is the same
            {
                if (currentIsBelowThreshold) //if current is less than threshold
                {
                    resource.Flavor = currentFlavor;
                    isRefillable = true;
                }
            }
            else isRefillable = true; //if not the same

            if (!isRefillable)
                throw context.CreateHttpResponseException<Keg>("Tap is not refillable yet", HttpStatusCode.BadRequest);
            var kegEntDto = AutoMapper.Mapper.Map<KegEntityDto>(resource);
            kegEntDto.TapId = tapId;
            var kegResDto = _repo.KegChange(kegEntDto);
            var kegRes = AutoMapper.Mapper.Map<Keg>(kegResDto);
            return Task.FromResult(new ResourceCreationResult<Keg, int>(kegRes));
        }
        private void SetContextId(IRequestContext context)
        {
            var officeid = context.UriParameters.GetByName<int>("OfficeId").EnsureValue(
                () => context.CreateHttpResponseException<Tap>("Please provide OfficeId", HttpStatusCode.BadRequest));
            var tapId = context.UriParameters.GetByName<int>("tapId").EnsureValue(
                () => context.CreateHttpResponseException<Tap>("Please provide TapId", HttpStatusCode.BadRequest));
            var linkParameter = new KegLinksParametersSource(officeid,tapId);
            context.LinkParameters.Set(linkParameter);
        }

        private void ValidateResourceInput(Keg resource, IRequestContext context)
        {
            //if (string.IsNullOrWhiteSpace(resource.Flavor))
            //    throw context.CreateHttpResponseException<Keg>("Please provide Flavor", HttpStatusCode.BadRequest);
            if (resource.Capacity <= 0)
                throw context.CreateHttpResponseException<Keg>("Capacity cannot be 0 or less", HttpStatusCode.BadRequest);
            if (resource.ThresholdPercentage <= 0)
                throw context.CreateHttpResponseException<Keg>("ThresholdPercentage cannot be 0 or less", HttpStatusCode.BadRequest);
            if (resource.ThresholdPercentage == 100)
                throw context.CreateHttpResponseException<Keg>("ThresholdPercentage cannot be 100 percent", HttpStatusCode.BadRequest);
        }
    }
}
