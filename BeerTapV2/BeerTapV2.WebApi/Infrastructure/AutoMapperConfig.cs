﻿using System;
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
            AutoMapper.Mapper.CreateMap<OfficeEntityDto, Dal.Model.Office>()
                .ForMember(dest => dest.Taps,opt  => opt.Ignore())
                .ReverseMap();
            //Office Entity to OfficeResourceDto
            //Dal to Repository
            AutoMapper.Mapper.CreateMap<Dal.Model.Office, OfficeResourceDto > ().ReverseMap();
            //Office ResourceDto to Office Resource
            //Repository to ApiService
            AutoMapper.Mapper.CreateMap<OfficeResourceDto, Office>().ReverseMap();

            AutoMapper.Mapper.CreateMap<Int32, Dal.Model.Office>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(s => s))
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.Taps, opt => opt.Ignore());
                //.ConvertUsing(x => new Dal.Model.Ta {Id=x});
            #endregion

            #region Tap Map Configuration

            AutoMapper.Mapper.CreateMap<Tap, TapEntityDto>()
                .ForMember(dest => dest.KegEntityDto, opt => opt.MapFrom(src=>src.Keg))
                .ForMember(dest => dest.OfficeId, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<TapEntityDto, Dal.Model.Tap>()
                .ForMember(dest => dest.Keg, opt => opt.MapFrom(src => src.KegEntityDto))
                .ForMember(dest => dest.Office, opt => opt.MapFrom(src => src.OfficeId))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<Dal.Model.Tap, TapResourceDto>()
                .ForMember(dest => dest.KegResourceDto, opt => opt.MapFrom(src => src.Keg));
            AutoMapper.Mapper.CreateMap<TapResourceDto, Tap>()
                .ForMember(dest => dest.Keg, opt => opt.MapFrom(src => src.KegResourceDto))
                .ForMember(dest => dest.TapState, opt => opt.ResolveUsing(src => GetState(src)));

            #endregion

            #region Keg Map Configuration

            AutoMapper.Mapper.CreateMap<Keg, KegEntityDto>()
                .ForMember(dest => dest.TapId, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.PercentageLeft, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<KegEntityDto, Dal.Model.Keg>()
                .ForMember(dest => dest.Milliliters, opt => opt.MapFrom(src => src.Capacity));
            AutoMapper.Mapper.CreateMap<Dal.Model.Keg, KegResourceDto>().ReverseMap();
            AutoMapper.Mapper.CreateMap<KegResourceDto, Keg>()
                .ForMember(dest => dest.PercentageLeft, opt => opt.MapFrom(x => (x.Milliliters/x.Capacity)*100));
                
                //.ReverseMap()
                //.ForMember(dest => dest.Milliliters, opt => opt.MapFrom(s=>(s.PercentageLeft / 100) * s.Capacity));

            #endregion

            #region Cup Map Configuration

            AutoMapper.Mapper.CreateMap<Cup, CupEntityDto>()
                .ForMember(dest => dest.TapId, opt => opt.Ignore())
                .ForMember(dest => dest.OfficeId, opt => opt.Ignore())
                .ReverseMap()
                .ForSourceMember(x => x.OfficeId, opt => opt.Ignore());
            AutoMapper.Mapper.CreateMap<CupResourceDto, Cup>().ReverseMap();

            #endregion
        }

        public static TapState GetState(TapResourceDto tapResDto)
        {
            var percentage = ((tapResDto.KegResourceDto.Milliliters / tapResDto.KegResourceDto.Capacity) * 100);
            if (percentage == 100)
                return TapState.New;
            if (percentage > tapResDto.KegResourceDto.ThresholdPercentage)
                return TapState.GoinDown;
            if (percentage <= tapResDto.KegResourceDto.ThresholdPercentage && percentage > 0)
                return TapState.AlmostDry;
            return TapState.ShesDryMate;
        }
    }
}