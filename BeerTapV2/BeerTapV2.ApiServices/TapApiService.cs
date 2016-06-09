using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    public class TapApiService : ITapApiService
    {
        private readonly IBeerTapRepository _repo;

        public TapApiService(IBeerTapRepository repo)
        {
            _repo = repo;
        }

        public TapApiService()
        {
            _repo = new BeerTapRepository();
        }

        public Task<Tap> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            SetContextId(context);
            var tapResDto = _repo.TapGet(id);
            var tapRes = AutoMapper.Mapper.Map<TapResourceDto, Tap>(tapResDto);
            return Task.FromResult(tapRes);

        }

        public Task<IEnumerable<Tap>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            SetContextId(context);
            var officeId = context.UriParameters.GetByName<int>("OfficeId").EnsureValue();
            var tapResDtos = _repo.TapGetMany(officeId);
            var tapRess = tapResDtos.Select(AutoMapper.Mapper.Map<TapResourceDto, Tap>) ;
            return Task.FromResult(tapRess.Select(x => x));
        }

        public Task<ResourceCreationResult<Tap, int>> CreateAsync(Tap resource, IRequestContext context, CancellationToken cancellation)
        {
            SetContextId(context);
            var officeid = context.UriParameters.GetByName<int>("OfficeId").EnsureValue();
            var tapEntDto = AutoMapper.Mapper.Map<TapEntityDto>(resource);
            var tapResDto = _repo.TapCreate(tapEntDto);
            var tapRes = AutoMapper.Mapper.Map<Tap>(tapResDto);
            return Task.FromResult(new ResourceCreationResult<Tap, int>(tapRes));
        }

        private void SetContextId(IRequestContext context)
        {
            var officeid = context.UriParameters.GetByName<int>("OfficeId").EnsureValue();
            var linkParameter = new TapLinksParametersSource (officeid);
            context.LinkParameters.Set(linkParameter);
        }
    }
}