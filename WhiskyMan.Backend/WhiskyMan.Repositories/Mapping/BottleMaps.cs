using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WhiskyMan.Entities;
using WhiskyMan.Models.Bottle;
using WhiskyMan.Repositories.Helpers;

namespace WhiskyMan.Repositories.Mapping
{
    static class BottleMaps
    {
        public static void CreateMaps(IMapperConfigurationExpression mce)
        {
            mce.CreateMap<BottleForAddition, Bottle>()
                .ForMember(
                    dest => dest.IsDrunk,
                    opt => opt.MapFrom(_ => true)); // not drunk by default

            mce.CreateMap<Bottle, BottleView>()
                .ForMember(
                    dest => dest.Tags,
                    opt => opt.MapFrom(b => b.BottleDescription.Tags.Select(t => t.Name).ToList()))
                .ForMember(
                    dest => dest.PictureUrl,
                    opt => opt.MapFrom(b => b.BottleDescription.PictureUrl))
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(b => b.BottleDescription.Name))
                .ForMember(
                    dest => dest.Distillery,
                    opt => opt.MapFrom(b => b.BottleDescription.Distillery))
                .ForMember(
                    dest => dest.Owners,
                    opt => opt.MapFrom(b => b.Owners.Select(o => $"{o.FirstName} {o.LastName}").ToList()));
        }
    }
}
