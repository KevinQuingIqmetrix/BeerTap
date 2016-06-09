using System.Threading;
using System.Threading.Tasks;
using BeerTapV2.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTapV2.ApiServices.ApiServiceInterface
{
    public interface ICupApiService:
        ICreateAResourceAsync<Cup,int>
    {

    }
}
