using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BeerTapV2.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTapV2.ApiServices.ApiServiceInterface
{
    public interface IOfficeApiService: 
        IGetAResource<Office,int>,
        IGetManyOfAResourceAsync<Office,int>,
        ICreateAResourceAsync<Office,int>,
        IUpdateAResourceAsync<Office,int>
    {
    }

    class OfficeApiService : IOfficeApiService
    {
        public Office Get(int id, IRequestContext context)
        {
            throw new NotImplementedException();
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
