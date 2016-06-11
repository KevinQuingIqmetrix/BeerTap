﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BeerTapV2.ApiServices.ApiServiceInterface;
using BeerTapV2.Model;
using BeerTapV2.Repository;
using IQ.Platform.Framework.WebApi;
using BeerTapV2.DTO;
using IQ.Platform.Framework.Common;

namespace BeerTapV2.ApiServices
{
    public class CupApiService : ICupApiService
    {
        private readonly IBeerTapRepository _repo;

        public CupApiService(IBeerTapRepository repo)
        {
            _repo = repo;
        }

        public CupApiService()
        {
            _repo = new BeerTapRepository();
        }

        public Task<ResourceCreationResult<Cup, int>> CreateAsync(Cup resource, IRequestContext context, CancellationToken cancellation)
        {
            SetContext(context);
            var cupEntDto = AutoMapper.Mapper.Map<DTO.CupEntityDto>(resource);
            cupEntDto.TapId = context.UriParameters.GetByName<int>("TapId").EnsureValue();
            var cupResDto = _repo.CupCreate(cupEntDto);
            var cupRes = AutoMapper.Mapper.Map<CupResourceDto,Cup>(cupResDto);
            return Task.FromResult(new ResourceCreationResult<Cup, int>(cupRes));
        }

        public void SetContext(IRequestContext context)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeId").EnsureValue();
            var tapId = context.UriParameters.GetByName<int>("TapId").EnsureValue();
            context.LinkParameters.Set(new CupLinksParametersSource(officeId,tapId));
        }
    }
}