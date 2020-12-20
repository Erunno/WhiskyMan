using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhiskyMan.Repositories.Mapping
{
    public static class MapperProvider
    {
        public static IMapper GetMapper()
            => new Mapper(GetConfig());

        public static MapperConfiguration GetConfig()
            => new MapperConfiguration(mce =>
            {
                UserMaps.CreateMaps(mce);
                BottleMaps.CreateMaps(mce);
                BottleDescriptionMaps.CreateMaps(mce);
            });
    }
}
