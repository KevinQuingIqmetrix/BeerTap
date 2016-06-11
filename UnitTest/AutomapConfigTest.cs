using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerTapV2.WebApi.Infrastructure;


namespace UnitTest
{
    [TestClass]
    public class AutomapConfigTest
    {
        [TestMethod]
        public void TestAutomapperConfig()
        {
            AutoMapperConfig.RegisterMapping();
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}
