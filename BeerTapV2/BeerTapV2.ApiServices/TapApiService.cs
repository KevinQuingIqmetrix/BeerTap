using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BeerTapV2.ApiServices.ApiServiceInterface;
using BeerTapV2.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTapV2.ApiServices
{
    public class TapApiService : ITapApiService
    {
        public Task<Tap> GetAsync(int id, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tap>> GetManyAsync(IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        public Task<ResourceCreationResult<Tap, int>> CreateAsync(Tap resource, IRequestContext context, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}