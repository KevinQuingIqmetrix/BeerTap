using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeerTapV2.ApiServices.ApiServiceInterface;
using BeerTapV2.DTO;
using BeerTapV2.Model;
using BeerTapV2.Repository;
using IQ.Platform.Framework.WebApi;

namespace BeerTapV2.ApiServices
{
    public class OfficeApiService : IOfficeApiService
    {
        private readonly IBeerTapRepository _repo;

        public OfficeApiService(IBeerTapRepository repo)
        {
            _repo = repo;
        }

        public OfficeApiService()
        {
            _repo = new BeerTapRepository();
        }

        public Task<Office> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var officedto = _repo.FindOffice(id);
            var office = AutoMapper.Mapper.Map<OfficeResourceDto, Office>(officedto);
            return Task.FromResult(office);
        }

        public Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var officesdto = _repo.GetOffices();
            var offices = officesdto.Select(x => AutoMapper.Mapper.Map<OfficeResourceDto, Office>(x));
            return Task.FromResult(offices);

        }

        public Task<ResourceCreationResult<Office, int>> CreateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeEntdto = AutoMapper.Mapper.Map<Office,OfficeEntityDto>(resource);
            var officeResdto = _repo.CreateOffice(officeEntdto);
            var officeRes = AutoMapper.Mapper.Map<OfficeResourceDto, Office>(officeResdto);
            return Task.FromResult(new ResourceCreationResult<Office, int>(officeRes));
        }

        public Task<Office> UpdateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}