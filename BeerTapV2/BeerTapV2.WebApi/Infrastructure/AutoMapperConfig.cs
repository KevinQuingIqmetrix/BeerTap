using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BeerTapV2.DTO;
using BeerTapV2.Model;

namespace BeerTapV2.WebApi.Infrastructure
{
    public class AutoMapperConfig
    {
        public static void RegisterMapping()
        {
            #region Office Map Configuration
            //Office Resource conversion to OfficeEntityDto
            //ApiService to Repository
            AutoMapper.Mapper.CreateMap<Office, OfficeEntityDto>().ReverseMap();
            //OfficeEntityDto to Office Entity
            //Repository to Dal
            AutoMapper.Mapper.CreateMap<OfficeEntityDto, Dal.Model.Office>().ReverseMap();
            //Office Entity to OfficeResourceDto
            //Dal to Repository
            AutoMapper.Mapper.CreateMap<Dal.Model.Office, OfficeResourceDto > ().ReverseMap();
            //Office ResourceDto to Office Resource
            //Repository to ApiService
            AutoMapper.Mapper.CreateMap<OfficeResourceDto, Office>().ReverseMap();
            #endregion

            #region Tap Map Configuration

            AutoMapper.Mapper.CreateMap<Tap, TapEntityDto>().ReverseMap();
            AutoMapper.Mapper.CreateMap<TapEntityDto, Dal.Model.Tap>().ReverseMap();
            AutoMapper.Mapper.CreateMap<Dal.Model.Tap, TapResourceDto>().ReverseMap();
            AutoMapper.Mapper.CreateMap<TapResourceDto, Tap>();

            #endregion
        }
    }
}