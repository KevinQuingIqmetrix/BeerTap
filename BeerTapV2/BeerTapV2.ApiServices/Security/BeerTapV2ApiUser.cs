using IQ.Platform.Framework.Common;
using IQ.Platform.Framework.WebApi.AspNet;
using IQ.Platform.Framework.WebApi.Services.Security;

namespace BeerTapV2.ApiServices.Security
{

    public class BeerTapV2ApiUser : ApiUser<UserAuthData>
    {
        public BeerTapV2ApiUser(string name, Option<UserAuthData> authData)
            : base(authData)
        {
            Name = name;
        }

        public string Name { get; private set; }

    }

    public class BeerTapV2UserFactory : ApiUserFactory<BeerTapV2ApiUser, UserAuthData>
    {
        public BeerTapV2UserFactory() :
            base(new HttpRequestDataStore<UserAuthData>())
        {
        }

        protected override BeerTapV2ApiUser CreateUser(Option<UserAuthData> auth)
        {
            return new BeerTapV2ApiUser("BeerTapV2 user", auth);
        }
    }

}
