using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;
using WhiskyMan.Models.BottleDescription;

namespace WhiskyMan.Repositories.Tests.Mapping
{
    class BottleDescriptionMapsTest : MappingTest
    {
        [Test]
        public void BottleDescriptionForAddition_BottleDescription()
            => TestMapping<BottleDescriptionForAddition, BottleDescription>(
                GetBottleDescriptionForAddition(),
                GetBottleDescription(),

                // don't check following properties
                nameof(BottleDescription.Id),
                nameof(BottleDescription.Bottles)
                );

        [Test]
        public void BottleDescription_BottleDescriptionReference()
            => TestMapping<BottleDescription, BottleDescriptionReference>(
                GetBottleDescription(),
                GetBottleDescriptionReference()
                );

        [Test]
        public void Tag_TagReference()
            => TestMapping<Tag, TagReference>(
                GetTag(),
                GetTagReference()
                );

        private BottleDescription GetBottleDescription()
            => new BottleDescription
            {
                Id = 1,
                Name = "Octa",
                Distillery = "Bruch",
                Age = 8,
                DescriptionText = "desc",
                PictureUrl = "url.com",
                Region = "reg",
                Voltage = 40,
                Active = true
            };

        private BottleDescriptionForAddition GetBottleDescriptionForAddition()
            => new BottleDescriptionForAddition
            {
                Name = "Octa",
                Distillery = "Bruch",
                Age = 8,
                DescriptionText = "desc",
                PictureUrl = "url.com",
                Region = "reg",
                Voltage = 40
            };

        private BottleDescriptionReference GetBottleDescriptionReference()
            => new BottleDescriptionReference
            {
                Id = 1,
                Name = "Octa - Bruch",
                PictureUrl = "url.com"
            };

        private Tag GetTag()
            => new Tag
            {
                Id = 2,
                Name = "smoky"
            };

        private TagReference GetTagReference()
            => new TagReference
            {
                Id = 2,
                Name = "smoky"
            };
    }
}
