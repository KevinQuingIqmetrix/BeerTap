using System;
using BeerTapV2.Services;

namespace BeerTapV2.ApiServices
{
    public interface IDomainServiceResolver
    {
        IDomainService Resolve(Type requestedServiceType);

        TService Resolve<TService>()
            where TService : IDomainService;
    }
}

namespace BeerTapV2.Services
{
    /// <summary> 
    /// Represents a specific domain service / repository used in IApiApplicationService implementations 
    /// </summary> 
    public interface IDomainService
    {
    }
}
