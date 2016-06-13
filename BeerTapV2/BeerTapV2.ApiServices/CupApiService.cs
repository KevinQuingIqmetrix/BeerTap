using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var cupEntDto = AutoMapper.Mapper.Map<CupEntityDto>(resource);
            cupEntDto.TapId = context.UriParameters.GetByName<int>("TapId").EnsureValue();
            cupEntDto.OfficeId = context.UriParameters.GetByName<int>("OfficeId").EnsureValue();
            var cupResDto = _repo.CupCreate(cupEntDto);
            if (cupResDto == null)
            {
                throw context.CreateHttpResponseException<Cup>("Tap not found", HttpStatusCode.BadRequest);
            }
            var cupRes = AutoMapper.Mapper.Map<CupResourceDto,Cup>(cupResDto);
            return Task.FromResult(new ResourceCreationResult<Cup, int>(cupRes));
        }

        public void SetContext(IRequestContext context)
        {
            var officeId = context.UriParameters.GetByName<int>("OfficeId").EnsureValue(
                () => context.CreateHttpResponseException<Tap>("Please provide OfficeId", HttpStatusCode.BadRequest));
            var tapId = context.UriParameters.GetByName<int>("TapId").EnsureValue(
                () => context.CreateHttpResponseException<Tap>("Please provide TapId", HttpStatusCode.BadRequest));
            context.LinkParameters.Set(new CupLinksParametersSource(officeId,tapId));
        }

        private void ValidateCup(IRequestContext context, Cup resource)
        {
            if (resource.Milliliters <= 0)
            {
                context.CreateHttpResponseException<Cup>("Milliliters cannot be 0 or less", HttpStatusCode.BadRequest);
            }
        }
    }
}
