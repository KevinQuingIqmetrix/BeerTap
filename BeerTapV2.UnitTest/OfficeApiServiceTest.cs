using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTapV2.ApiServices;
using BeerTapV2.ApiServices.ApiServiceInterface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IQ.Platform.Framework.WebApi;
using BeerTapV2.Repository;

namespace BeerTapV2.UnitTest
{

    [TestClass]
    public class OfficeApiServiceTest
    {
        Moq.Mock<IRequestContext> _MockRequestContext;
        IRequestContext _RequestContext;
        Moq.Mock<IBeerTapRepository> _MockRepo;
        IBeerTapRepository _Repo;
        
        IOfficeApiService _api;

        public OfficeApiServiceTest()
        {
            _MockRequestContext = new Moq.Mock<IRequestContext>();
            _RequestContext = _MockRequestContext.Object;
            _MockRepo = new Moq.Mock<IBeerTapRepository>();
            _Repo = _MockRepo.Object;

            _api = new OfficeApiService(_Repo);
        }

        [TestMethod]
        public void GetAsync_OfficeWithIdExists_CorrespondingPropertiesShouldHaveSameValues()
        {
            var idPassed = 1;
            _api.GetAsync(idPassed, _RequestContext, new System.Threading.CancellationToken());

            _MockRepo.Verify(t => t.FindOffice(idPassed));
            

        }
    }
}
