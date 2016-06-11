using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BeerTapV2.ApiServices.ApiServiceInterface;
using BeerTapV2.DTO;
using BeerTapV2.Model;
using BeerTapV2.Common;
using BeerTapV2.Repository;
using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi;

namespace BeerTapV2.ApiServices
{
    public class OfficeApiService : IOfficeApiService
    {
        private readonly IBeerTapRepository _repo;
        private readonly Common.IAutoMap _autoMap;
        public OfficeApiService(IBeerTapRepository repo, IAutoMap autoMap)
        {
            _repo = repo;
            _autoMap = autoMap;
        }

        public OfficeApiService()
        {
            _repo = new BeerTapRepository();
            _autoMap = new AutoMap();
        }

        public Task<Office> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            var officedto = _repo.FindOffice(id);
            var office = _autoMap.Map<OfficeResourceDto, Office>(officedto);
            return Task.FromResult(office);
        }

        public Task<IEnumerable<Office>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            var officesdto = _repo.GetOffices();
            var offices = officesdto.Select(x => _autoMap.Map<OfficeResourceDto, Office>(x));
            return Task.FromResult(offices);

        }

        public Task<ResourceCreationResult<Office, int>> CreateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeEntdto = _autoMap.Map<Office,OfficeEntityDto>(resource);
            var officeResdto = _repo.CreateOffice(officeEntdto);
            var officeRes = _autoMap.Map<OfficeResourceDto, Office>(officeResdto);
            return Task.FromResult(new ResourceCreationResult<Office, int>(officeRes));
        }

        public Task<Office> UpdateAsync(Office resource, IRequestContext context, CancellationToken cancellation)
        {
            var officeEntDto = _autoMap.Map<Office, OfficeEntityDto>(resource);
            //set id of office to update
            var id = context.UriParameters.GetByName<int>("Id").EnsureValue();
            officeEntDto.Id = id;

            var officeResDto = _repo.UpdateOffice(officeEntDto);
            var officeRes = _autoMap.Map<OfficeResourceDto, Office>(officeResDto);
            return Task.FromResult(officeRes);
        }
    }
}