using System;
using System.Threading;
using BeerTapV2.ApiServices.ApiServiceInterface;
using IQ.Platform.Framework.WebApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BeerTapV2.ApiServices;
using BeerTapV2.Common;
using BeerTapV2.Model;
using BeerTapV2.DTO;
using BeerTapV2.Repository;

namespace UnitTest
{
    [TestClass]
    public class OfficeApiTest
    {
        private IOfficeApiService _api;
        [TestMethod]
        public void GetOffice_WhenPassedExistingOfficeId_ReturnOffice()
        {
            var mocks = new OfficeMocks();
            _api = new OfficeApiService(mocks.MockRepo.Object,mocks.MockMap.Object);

            var id = 1;
            var name = "Vancouver";
            var officeResDto = new OfficeResourceDto {Id = id, Name = name};
            var office = new Office {Id = id, Name = name};
            mocks.MockRepo.Setup(x => x.FindOffice(It.IsAny<int>())).Returns(() => officeResDto);
            mocks.MockMap.Setup(x => x.Map<OfficeResourceDto, Office>(It.IsAny<OfficeResourceDto>())).Returns(() => office);


            var getAsyncReturn = _api.GetAsync(id, mocks.MockContext.Object, new CancellationToken());
            var returnValue = getAsyncReturn.Result;
            Assert.AreEqual(id,returnValue.Id);
            Assert.AreEqual(name, returnValue.Name);
        }

        //[TestMethod]
        //public void GetOffice_WhenPassedNonExistentOfficeId_ThrowException()
        //{

        //    var mocks = new OfficeMocks();
        //    _api = new OfficeApiService(mocks.MockRepo.Object, mocks.MockMap.Object);

        //    var id = 1;
        //    var name = "Vancouver";
        //    var officeResDto = new OfficeResourceDto { Id = id, Name = name };
        //    var office = new Office { Id = id, Name = name };
        //    mocks.MockRepo.Setup(x => x.FindOffice(It.IsAny<int>())).Returns(() => officeResDto);
        //    mocks.MockMap.Setup(x => x.Map<OfficeResourceDto, Office>(It.IsAny<OfficeResourceDto>())).Returns(() => office);


        //    var getAsyncReturn = _api.GetAsync(id, mocks.MockContext.Object, new CancellationToken());
        //    var returnValue = getAsyncReturn.Result;
        //    Assert.AreEqual(id, returnValue.Id);
        //    Assert.AreEqual(name, returnValue.Name);
        //}
    }

    public class OfficeMocks
    {
        public Mock<IRequestContext> MockContext;
        public Mock<IBeerTapRepository> MockRepo;
        public Mock<IAutoMap> MockMap;

        public OfficeMocks()
        {
            MockContext = new Mock<IRequestContext>();
            MockRepo = new Mock<IBeerTapRepository>();
            MockMap = new Mock<IAutoMap>();
        }
    }
}
