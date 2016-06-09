using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using BeerTapV2.DTO;
using BeerTapV2.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BeerTapV2.UnitTest
{
    [TestClass]
    //TODO: use automapperconfig in webapi hypermedia folder instead of creating configurations again
    public class AutomapperConfigTest
    {
        [TestMethod]
        public void TapEntityToDto_ConfigurationIsValid()
        {
            AutoMapper.Mapper.CreateMap<TapResourceDto, Tap>()
                .ForMember(dest => dest.Id,opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TapState,opt => opt.Ignore());
            var tapResDtos = new List<TapResourceDto>
            {
                new TapResourceDto
                {
                    Id = 1
                },
                new TapResourceDto
                {
                    Id = 2
                }
            };
            var taps = Mapper.Map<List<Tap>>(tapResDtos);
            
            
            Assert.AreEqual(tapResDtos[0].Id,taps[0].Id);
            Assert.AreEqual(tapResDtos[1].Id, taps[1].Id);
            Mapper.AssertConfigurationIsValid();
        }
    }
}
