using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.AspNet.Handlers;
using IQ.Platform.Framework.WebApi.Services.Security;
using BeerTapV2.ApiServices.Security;

namespace BeerTapV2.WebApi.Handlers
{
    public class PutYourApiSafeNameUserContextProvidingHandler
            : ApiSecurityContextProvidingHandler<BeerTapV2ApiUser, NullUserContext>
    {

        public PutYourApiSafeNameUserContextProvidingHandler(
            IStoreDataInHttpRequest<BeerTapV2ApiUser> apiUserInRequestStore)
            : base(new BeerTapV2UserFactory(), CreateContextProvider(), apiUserInRequestStore)
        {
        }

        static ApiUserContextProvider<BeerTapV2ApiUser, NullUserContext> CreateContextProvider()
        {
            return
                new ApiUserContextProvider<BeerTapV2ApiUser, NullUserContext>(_ => new NullUserContext());
        }
    }
}