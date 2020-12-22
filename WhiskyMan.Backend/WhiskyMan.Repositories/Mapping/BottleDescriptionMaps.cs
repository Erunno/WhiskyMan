using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;
using WhiskyMan.Models.BottleDescription;

namespace WhiskyMan.Repositories.Mapping
{
    class BottleDescriptionMaps
    {
        public static void CreateMaps(IMapperConfigurationExpression mce)
        {
            mce.CreateMap<BottleDescriptionForAddition, BottleDescription>()
                .ForMember(
                    dest => dest.Active,
                    opt => opt.MapFrom(_ => true)); // active by default
            mce.CreateMap<BottleDescription, BottleDescriptionReference>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(des => $"{des.Name} - {des.Distillery}"));
        }
    }
}
