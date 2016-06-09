using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using BeerTapV2.DTO;
using BeerTapV2.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerTapV2.WebApi.Infrastructure;

namespace BeerTapV2.UnitTest
{
    [TestClass]
    public class AutomapperConfigTest
    {
        public AutomapperConfigTest()
        {
            AutoMapperConfig.RegisterMapping();
        }
        [TestMethod]
        public void TapEntityToDto_ConfigurationIsValid()
        {
            Mapper.AssertConfigurationIsValid();
        }
    }
}
