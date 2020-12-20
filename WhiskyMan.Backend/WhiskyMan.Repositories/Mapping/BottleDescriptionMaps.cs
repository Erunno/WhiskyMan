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
            mce.CreateMap<BottleDescriptionForAddition, BottleDescription>();
        }
    }
}
