using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTapV2.ApiServices;
using BeerTapV2.ApiServices.ApiServiceInterface;
using BeerTapV2.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IQ.Platform.Framework.WebApi;
using BeerTapV2.Repository;
using Moq;

namespace BeerTapV2.UnitTest
{

    [TestClass]
    public class OfficeApiServiceTest
    {
        private IOfficeApiService _api;

        [TestMethod]
        public void GetAsync_OfficeWithIdExists_CorrespondingPropertiesShouldHaveSameValues()
        {
            //Arrange
            Mock<IRequestContext> mockContext = new Mock<IRequestContext>();
            Mock<IBeerTapRepository> mockRepo = new Mock<IBeerTapRepository>();
            _api = new OfficeApiService(mockRepo.Object);
            
            var officeResDto = new OfficeResourceDto { Id = 1, Name = "Vancouver" };
            mockRepo.Setup(x => x.FindOffice(It.IsAny<int>())).Returns(
                () => new OfficeResourceDto { Id = officeResDto.Id, Name = officeResDto.Name });

            //Act
            var GetAsyncReturn = _api.GetAsync(officeResDto.Id, mockContext.Object, new System.Threading.CancellationToken());

            //Assert
            mockRepo.Verify(t => t.FindOffice(officeResDto.Id));
            //TODO: test that return(GetAsyncReturn) data is same as the test request data

        }
    }
}
