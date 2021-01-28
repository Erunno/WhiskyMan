using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;
using WhiskyMan.Entities.Auth;
using WhiskyMan.Models.Bottle;

namespace WhiskyMan.Repositories.Tests.Mapping
{
    class BottleMapsTest : MappingTest
    {
        [Test]
        public void UserForRegister_UserForAuthModel()
            => TestMapping<BottleForAddition, Bottle>(
                input: GetBottleForAddition(),
                expected: GetBottle(),

                // don't check following properties
                nameof(Bottle.Id),
                nameof(Bottle.Owners),
                nameof(Bottle.Transactions),
                nameof(Bottle.BottleDescription),
                nameof(Bottle.Ownerships)
                );

        [Test]
        public void Bottle_BottleView()
        {
            // arrange
            var bottle = GetBottle();
            var bottleView = GetBottleView();

            // act + assert
            var actual = TestMapping<Bottle, BottleView>(
                input: bottle,
                expected: bottleView,

                // don't check following properties
                nameof(BottleView.Owners),
                nameof(BottleView.Tags)
                );

            // addintional asserts
            CollectionAssert.AreEquivalent(
                expected: bottleView.Tags,
                actual: actual.Tags);

            CollectionAssert.AreEquivalent(
                expected: bottleView.Owners,
                actual: actual.Owners);

        }


        private Bottle GetBottle()
            => new Bottle
            {
                Id = 1,
                Amount_ml = 700,
                BottleDescriptionId = 2,
                BottlePrice = 1000,
                IsDrunk = true,
                ShotPrice = 20,
                WastePercent = 15,
                Owners = new Collection<User>
                {
                    new User { Id = 1, FirstName = "F1", LastName = "L1" },
                    new User { Id = 2, FirstName = "F2", LastName = "L2" },
                    new User { Id = 3, FirstName = "F3", LastName = "L3" }
                },
                BottleDescription = new BottleDescription
                {
                    Id = 2,
                    Name = "desc name",
                    Distillery = "dist",
                    Active = true,
                    PictureUrl = "url",
                    Region = "region",
                    Age = 8,
                    Tags = new List<Tag>() { new Tag { Id = 3, Name = "tag" } },
                    DescriptionText = "desc text",
                    Voltage = 40
                }
            };

        private BottleForAddition GetBottleForAddition()
            => new BottleForAddition
            {
                Amount_ml = 700,
                BottleDescriptionId = 2,
                BottlePrice = 1000,
                OwnerIds = new List<long> { 1, 2, 3 },
                ShotPrice = 20,
                WastePercent = 15
            };

        private BottleView GetBottleView()
            => new BottleView
            {
                Id = 1,
                Name = "desc name",
                Distillery = "dist",
                PictureUrl = "url",
                Owners = new List<string>()
                {
                    "F1 L1", "F2 L2", "F3 L3"
                },
                Tags = new List<string>() { "tag" },
                ShotPrice = 20
            };
    }
}
