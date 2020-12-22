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
        }
    }
}
