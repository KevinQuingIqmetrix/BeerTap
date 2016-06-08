using System.Linq;
using System.Text;
using BeerTapV2.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTapV2.ApiServices.ApiServiceInterface
{
    public interface ITapApiService :
        IGetAResourceAsync<Tap, int>,
        IGetManyOfAResourceAsync<Tap, int>,
        ICreateAResourceAsync<Tap, int>
    {
    }
}
