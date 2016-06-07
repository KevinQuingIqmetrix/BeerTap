using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BeerTapV2.ApiServices.ApiServiceInterface;
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
            var office = new Office
            {
                Id = officedto.Id,
                Name = officedto.Name
            };
            //TODO: automap OfficeResourceDTO to Office(BeerTapV2.Model)
            return Task.FromResult(office);
        }

        public Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResourceCreationResult<Office, int>> CreateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<Office> UpdateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}