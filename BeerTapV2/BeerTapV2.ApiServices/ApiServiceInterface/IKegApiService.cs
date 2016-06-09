using BeerTapV2.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTapV2.ApiServices.ApiServiceInterface
{
    public interface IKegApiService:
        ICreateAResourceAsync<Keg,int>
    {
    }
}