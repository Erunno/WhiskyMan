using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;
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
                    new User { Id = 1 },
                    new User { Id = 2 },
                    new User { Id = 3 }
                }
            };

        private BottleForAddition GetBottleForAddition()
            => new BottleForAddition
            {
                Amount_ml = 700,
                BottleDescriptionId = 2,
                BottlePrice = 1000,
                OwnerIds = new List<int> { 1, 2, 3 },
                ShotPrice = 20,
                WastePercent = 15
            };
    }
}
