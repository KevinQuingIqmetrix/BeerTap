using System.Linq;
using System.Text;
using BeerTapV2.Model;
using IQ.Platform.Framework.WebApi;

namespace BeerTapV2.ApiServices.ApiServiceInterface
{
    public interface IOfficeApiService: 
        IGetAResourceAsync<Office,int>,
        IGetManyOfAResourceAsync<Office,int>,
        ICreateAResourceAsync<Office,int>,
        IUpdateAResourceAsync<Office,int>
    {
    }
}
