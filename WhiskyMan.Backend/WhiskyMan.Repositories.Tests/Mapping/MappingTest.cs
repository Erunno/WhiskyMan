using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Repositories.Mapping;

namespace WhiskyMan.Repositories.Tests.Mapping
{
    class MappingTest
    {
        protected void TestMapping<TSource, TDestination>(TSource input, TDestination expected) 
        {
            // arrange
            var mapper = MapperProvider.GetMapper();

            // act
            var actual = mapper.Map<TDestination>(input);

            // assert
            Assert.AreEqual(expected, actual);
        }

        protected void TestMapping<TSource, TDestination>(TSource input, TDestination expected, params string[] exceptProperties)
        {
            // arrange
            var mapper = MapperProvider.GetMapper();

            // act
            var actual = mapper.Map<TDestination>(input);

            // assert
            var propertiesToCheck =
                typeof(TDestination)
                .GetProperties()
                .Where(p => !exceptProperties.Contains(p.Name));

            foreach (var prop in propertiesToCheck)
                Assert.AreEqual(prop.GetValue(expected), prop.GetValue(actual),
                    $"Unexpected value of property {typeof(TDestination).Name}.{prop.Name}");
        }
    }
}
