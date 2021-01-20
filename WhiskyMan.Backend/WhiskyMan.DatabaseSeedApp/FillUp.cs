using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;
using WhiskyMan.Entities.Auth;
using WhiskyMan.Repositories;

namespace WhiskyMan.DatabaseSeedApp
{
    class FillUp
    {

        public static void Run(DataContext context, UserManager<User> userManager)
        {
            var passwd = "Passwd001";

            #region Roles

            #endregion

            #region Users
            var users = new Dictionary<string, User>
            {
                {
                    "admin",
                    new User
                    {
                        Id = 1,
                        UserName = "admin",
                        Email = "admin@email.com",
                        FirstName = "Admin",
                        LastName = "Adminovski",
                        Active = true,
                        PictureUrl = GetPictureUrl(),
                    }
                },
                {
                    "user_1",
                    new User
                    {
                        Id = 2,
                        UserName = "first_regular",
                        Email = "first_regular@email.com",
                        FirstName = "First",
                        LastName = "Firtovski",
                        Active = true,
                        PictureUrl = GetPictureUrl(),
                    }
                },
                {
                    "user_2",
                    new User
                    {
                        Id = 3,
                        UserName = "second_regular",
                        Email = "second_regular@email.com",
                        FirstName = "Second",
                        LastName = "Secondovski",
                        Active = true,
                        PictureUrl = GetPictureUrl(),
                    }
                },

                {
                    "owner_1",
                    new User
                    {
                        Id = 4,
                        UserName = "owner_user",
                        Email = "owner_user@email.com",
                        FirstName = "Owner",
                        LastName = "Ownerovski",
                        Active = true,
                        PictureUrl = GetPictureUrl(),
                    }
                },
                {
                    "owner_2",
                    new User
                    {
                        Id = 5,
                        UserName = "owner2_user",
                        Email = "owner2_user@email.com",
                        FirstName = "Owner",
                        LastName = "Ownerovski jr.",
                        Active = true,
                        PictureUrl = GetPictureUrl(),
                    }
                },
                {
                    "inactive",
                    new User
                    {
                        Id = 6,
                        UserName = "inactive_user",
                        Email = "inactive_user@email.com",
                        FirstName = "Inactiv",
                        LastName = "Inactivski",
                        Active = false,
                        PictureUrl = GetPictureUrl(),
                    }
                }
            };
            #endregion

            #region Tags
            var tags = new Dictionary<string, Tag>
            {
                {
                    "smoky",
                    new Tag
                    {
                        Id = 1,
                        Name = "smoky",
                        Active = true
                    }
                },
                {
                    "cherry",
                    new Tag
                    {
                        Id = 2,
                        Name = "cherry",
                        Active = true
                    }
                },
                {
                    "cask strength",
                    new Tag
                    {
                        Id = 3,
                        Name = "cask strength",
                        Active = true
                    }
                },
                {
                    "beginner",
                    new Tag
                    {
                        Id = 4,
                        Name = "beginner",
                        Active = true
                    }
                },
                {
                    "advanced",
                    new Tag
                    {
                        Id = 5,
                        Name = "advanced",
                        Active = true
                    }
                },
                {
                    "evening start",
                    new Tag
                    {
                        Id = 6,
                        Name = "evening start",
                        Active = true
                    }
                },
                {
                    "evening end",
                    new Tag
                    {
                        Id = 7,
                        Name = "evening end",
                        Active = true
                    }
                },
                {
                    "premium",
                    new Tag
                    {
                        Id = 8,
                        Name = "premium",
                        Active = true
                    }
                },
                {
                    "peated",
                    new Tag
                    {
                        Id = 9,
                        Name = "peated",
                        Active = true
                    }
                },
                {
                    "inactive_1",
                    new Tag
                    {
                        Id = 10,
                        Name = "inactive tag 1",
                        Active = false
                    }
                },
                {
                    "inactive_2",
                    new Tag
                    {
                        Id = 11,
                        Name = "inactive tag 2",
                        Active = false
                    }
                },
                {
                    "single malt",
                    new Tag
                    {
                        Id = 12,
                        Name = "single malt",
                        Active = true
                    }
                },
            };
            #endregion

            #region Bottle descriptions
            var bottleDescriptions = new Dictionary<string, BottleDescription>
            {
                {
                    "octomore",
                    new BottleDescription
                    {
                        Id = 1,
                        Name = "Octomore 8.3",
                        Distillery = "Bruichladdich",
                        Voltage = 61.2m,
                        Age = 5,
                        Region = "Islay",
                        Active = true,
                        PictureUrl = @"https://www.alkohol.cz/images/preview/thumb_340_380_1576404500Octomore-10.3-1.png",
                        Tags = new List<Tag> { tags["smoky"], tags["evening end"], tags["advanced"], tags["cask strength"] },
                        DescriptionText = "Bruichladdich's Octomore expressions are know for being incredibly well-peated - but this one takes the proverbial biscuit and throws it out a window. The Octomore Masterclass_08.3 weighs in at a massive 309 PPM, making this the most heavily-peated Octomore to date! It was aged for 5 years in 56% first-fill bourbon casks, while the rest was filled into ex-Paulliac, Ventoux, Rhone and Burgundy casks.",
                    }
                },
                {
                    "talisker",
                    new BottleDescription
                    {
                        Id = 2,
                        Name = "Talisker 10y",
                        Distillery = "Talisker",
                        Voltage = 45.8m,
                        Age = 10,
                        Region = "Island",
                        Active = true,
                        PictureUrl = @"https://www.alkohol.cz/images/preview/thumb_340_380_1504021208macallan-12-year-old-double-cask-whisky.jpg",
                        Tags = new List<Tag> { tags["beginner"], tags["single malt"], tags["inactive_2"] },
                        DescriptionText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer pretium ut dolor in venenatis. In mattis tortor est, non scelerisque arcu ultricies non. Aliquam massa nunc, posuere vitae neque vitae, aliquam eleifend turpis. Cras nec ullamcorper ligula, in vehicula lectus. Morbi ultrices consequat leo ultrices mollis. Mauris mattis sagittis ligula aliquam suscipit. Donec volutpat felis ac nulla consectetur hendrerit. Etiam pharetra ligula ante, sit amet pulvinar tellus accumsan ac. Donec ut faucibus magna. Sed eget commodo sapien. Vivamus vel sodales odio. Sed vel viverra ligula."
                    }
                },
                {
                    "glenfiddich",
                    new BottleDescription
                    {
                        Id = 3,
                        Name = "Glenfiddich 12y",
                        Distillery = "Glenfiddich",
                        Voltage = 40m,
                        Age = 12,
                        Region = "Spayside",
                        Active = true,
                        PictureUrl = @"https://www.alkohol.cz/images/preview/thumb_340_380_1573459633glenfiddich-12-gb.jpg",
                        Tags = new List<Tag> { tags["inactive_1"], tags["evening start"], tags["beginner"] },
                        DescriptionText = "Donec facilisis magna turpis, eget sagittis turpis tincidunt vitae. Aliquam cursus risus nisi, sed sollicitudin quam tempus sed. Nullam sodales sapien et erat dapibus, in faucibus est efficitur. Aliquam ut erat purus. Curabitur accumsan suscipit faucibus. Vestibulum euismod diam vel hendrerit ultricies. Mauris vitae pellentesque dolor. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec varius id mi quis posuere. Vestibulum suscipit tellus sit amet urna rhoncus bibendum."
                    }
                },
                {
                    "oban",
                    new BottleDescription
                    {
                        Id = 4,
                        Name = "Oban 14y",
                        Distillery = "Oban",
                        Voltage = 43m,
                        Age = 14,
                        Region = "Highland",
                        Active = true,
                        PictureUrl = @"https://www.alkohol.cz/images/preview/thumb_340_380_1377252742_oban1.jpg",
                        Tags = new List<Tag> { tags["evening start"], tags["beginner"] },
                        DescriptionText = "Fusce velit mi, dignissim non suscipit a, consectetur eget leo. Ut ut ipsum rhoncus velit ultrices mattis nec a libero. Vestibulum elementum consectetur odio sit amet porttitor. Quisque aliquam turpis ut lectus ornare, a volutpat mauris cursus. Curabitur bibendum mauris hendrerit velit feugiat tempor. Proin imperdiet sit amet quam in volutpat. Vivamus vitae bibendum ante. Sed tempus quis quam non ultricies. Proin non est et sem auctor tempor. Phasellus fringilla tortor turpis, vitae suscipit nisi condimentum in. Vivamus eu nisi tempus, facilisis orci vitae, congue lectus."
                    }
                },
                {
                    "inactive_des",
                    new BottleDescription
                    {
                        Id = 5,
                        Name = "Inactive",
                        Distillery = "Inactive distillery",
                        Voltage = 45m,
                        Age = 20,
                        Region = "Islay",
                        Active = false,
                        PictureUrl = @"https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2F3.bp.blogspot.com%2F_AJ4XCmMMAI4%2FTOGJUckfCzI%2FAAAAAAAAAC0%2Fgm2iG4G19NA%2Fs1600%2Fshoopbottle22-01.png&f=1&nofb=1",
                        Tags = new List<Tag> { tags["smoky"], tags["evening end"], tags["advanced"], tags["inactive_2"] },
                        DescriptionText = "Cras vitae pretium neque. Nulla at fringilla dui. Maecenas egestas dui vitae nunc maximus ultricies. Donec elementum libero et nisi volutpat, eget faucibus mauris accumsan. Curabitur ultricies sollicitudin congue. Praesent consectetur lacus vel mauris vulputate facilisis. Etiam aliquet mauris ac odio hendrerit laoreet."
                    }
                },
                {
                    "macallan",
                    new BottleDescription
                    {
                        Id = 6,
                        Name = "Macallan Double Cask",
                        Distillery = "Macallan Double Cask",
                        Voltage = 40m,
                        Age = 12,
                        Region = "Speyside",
                        Active = false,
                        PictureUrl = @"https://external-content.duckduckgo.com/iu/?u=http%3A%2F%2F3.bp.blogspot.com%2F_AJ4XCmMMAI4%2FTOGJUckfCzI%2FAAAAAAAAAC0%2Fgm2iG4G19NA%2Fs1600%2Fshoopbottle22-01.png&f=1&nofb=1",
                        Tags = new List<Tag> { tags["single malt"], tags["evening start"], tags["advanced"], tags["inactive_2"] },
                        DescriptionText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam consequat velit in dolor tincidunt viverra. Maecenas at arcu pellentesque velit bibendum fringilla sed tempus urna. Suspendisse mattis diam metus. Sed vulputate tellus dignissim, luctus diam et, ultrices tortor. Cras magna ligula, faucibus pellentesque imperdiet ut, porttitor eu ex. Sed rutrum ornare mattis. Mauris in ornare lorem. Fusce pretium molestie nisl non auctor. Mauris mollis sollicitudin venenatis. Integer tempus, ligula quis tempus molestie, sapien libero ultricies enim, eget sagittis enim lacus ac tellus. Nam tempus felis facilisis ipsum convallis, quis porta lectus interdum. Nulla turpis felis, fermentum at viverra nec, molestie id mauris. Aliquam sed metus nulla. Proin in mauris quis lectus scelerisque interdum. Donec hendrerit pellentesque nisi, in molestie massa condimentum sit amet."
                    }
                }
            };
            #endregion

            #region Bottles
            var bottles = new Dictionary<string, Bottle>
            {
                {
                    "octo ao1",
                    new Bottle
                    {
                        Id = 1,
                        BottleDescription = bottleDescriptions["octomore"],
                        Amount_ml = 700,
                        BottlePrice = 3456,
                        ShotPrice = 150,
                        IsDrunk = false,
                        WastePercent = 15,
                        Owners = new List<User> { users["admin"], users["owner_1"] },
                    }
                },
                {
                    "octo o2",
                    new Bottle
                    {
                        Id = 2,
                        BottleDescription = bottleDescriptions["octomore"],
                        Amount_ml = 700,
                        BottlePrice = 2967,
                        ShotPrice = 130,
                        IsDrunk = false,
                        WastePercent = 15,
                        Owners = new List<User> { users["owner_2"] },
                    }
                },
                {
                    "oban o2 drunk",
                    new Bottle
                    {
                        Id = 3,
                        BottleDescription = bottleDescriptions["oban"],
                        Amount_ml = 1000,
                        BottlePrice = 1600,
                        ShotPrice = 80,
                        IsDrunk = true,
                        WastePercent = 15,
                        Owners = new List<User> { users["owner_1"], users["owner_2"] },
                    }
                },
                {
                    "oban o1 drunk",
                    new Bottle
                    {
                        Id = 4,
                        BottleDescription = bottleDescriptions["oban"],
                        Amount_ml = 700,
                        BottlePrice = 1389,
                        ShotPrice = 85,
                        IsDrunk = false,
                        WastePercent = 15,
                        Owners = new List<User> { users["owner_1"] },
                    }
                },
                {
                    "talisker i",
                    new Bottle
                    {
                        Id = 5,
                        BottleDescription = bottleDescriptions["talisker"],
                        Amount_ml = 700,
                        BottlePrice = 1049,
                        ShotPrice = 65,
                        IsDrunk = false,
                        WastePercent = 15,
                        Owners = new List<User> { users["inactive"] },
                    }
                },
                {
                    "macallan a",
                    new Bottle
                    {
                        Id = 6,
                        BottleDescription = bottleDescriptions["macallan"],
                        Amount_ml = 700,
                        BottlePrice = 2899,
                        ShotPrice = 145,
                        IsDrunk = false,
                        WastePercent = 15,
                        Owners = new List<User> { users["admin"] },
                    }
                },
                {
                    "glenfiddich ao1o2",
                    new Bottle
                    {
                        Id = 7,
                        BottleDescription = bottleDescriptions["glenfiddich"],
                        Amount_ml = 700,
                        BottlePrice = 819,
                        ShotPrice = 55,
                        IsDrunk = false,
                        WastePercent = 15,
                        Owners = new List<User> { users["admin"], users["owner_1"], users["owner_2"] },
                    }
                },
                {
                    "glenfiddich o1o2",
                    new Bottle
                    {
                        Id = 8,
                        BottleDescription = bottleDescriptions["glenfiddich"],
                        Amount_ml = 700,
                        BottlePrice = 800,
                        ShotPrice = 60,
                        IsDrunk = false,
                        WastePercent = 15,
                        Owners = new List<User> { users["owner_1"], users["owner_2"] },
                    }
                },
                {
                    "glenfiddich ai",
                    new Bottle
                    {
                        Id = 9,
                        BottleDescription = bottleDescriptions["glenfiddich"],
                        Amount_ml = 700,
                        BottlePrice = 850,
                        ShotPrice = 50,
                        IsDrunk = false,
                        WastePercent = 15,
                        Owners = new List<User> { users["admin"], users["inactive"] },
                    }
                },
                {
                    "inactive_des ai",
                    new Bottle
                    {
                        Id = 10,
                        BottleDescription = bottleDescriptions["inactive_des"],
                        Amount_ml = 1000,
                        BottlePrice = 1545,
                        ShotPrice = 70,
                        IsDrunk = false,
                        WastePercent = 15,
                        Owners = new List<User> { users["admin"], users["inactive"] },
                    }
                },
                {
                    "inactive_des o1",
                    new Bottle
                    {
                        Id = 11,
                        BottleDescription = bottleDescriptions["inactive_des"],
                        Amount_ml = 1000,
                        BottlePrice = 1500,
                        ShotPrice = 65,
                        IsDrunk = true,
                        WastePercent = 15,
                        Owners = new List<User> { users["owner_1"] },
                    }
                },
            };
            #endregion

            #region Special prices
            var specialPrices = new List<SpecialPrice>
            {
                // admin
                new SpecialPrice { User = users["admin"], Bottle = bottles["octo o2"], Price = 20 },
                new SpecialPrice { User = users["admin"], Bottle = bottles["talisker i"], Price = 30 },
                new SpecialPrice { User = users["admin"], Bottle = bottles["macallan a"], Price = 50 },
            };
            #endregion

            #region Transactions
            var transactions = new List<Transaction>
            {
                // user 1
                new Transaction { Buyer = users["user_1"], Bottle = bottles["octo ao1"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["octo ao1"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["octo ao1"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["oban o2 drunk"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["oban o2 drunk"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["glenfiddich ao1o2"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["glenfiddich ao1o2"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["glenfiddich ao1o2"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["glenfiddich o1o2"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["glenfiddich o1o2"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["glenfiddich o1o2"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["inactive_des ai"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["inactive_des ai"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["inactive_des o1"], CreationTime = new DateTime(2020, 11, 24) },

                new Transaction { Buyer = users["user_1"], Bottle = bottles["octo ao1"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["talisker i"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["talisker i"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["talisker i"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["macallan a"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["macallan a"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["macallan a"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["user_1"], Bottle = bottles["macallan a"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },

                // user 2
                new Transaction { Buyer = users["user_2"], Bottle = bottles["octo ao1"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["user_2"], Bottle = bottles["oban o2 drunk"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["user_2"], Bottle = bottles["oban o2 drunk"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["user_2"], Bottle = bottles["glenfiddich ao1o2"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["user_2"], Bottle = bottles["glenfiddich ao1o2"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["user_2"], Bottle = bottles["glenfiddich o1o2"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["user_2"], Bottle = bottles["glenfiddich o1o2"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["user_2"], Bottle = bottles["glenfiddich o1o2"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["user_2"], Bottle = bottles["inactive_des ai"], CreationTime = new DateTime(2020, 11, 24) },

                new Transaction { Buyer = users["user_2"], Bottle = bottles["octo ao1"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["user_2"], Bottle = bottles["talisker i"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["user_2"], Bottle = bottles["talisker i"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["user_2"], Bottle = bottles["macallan a"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },

                // admin
                new Transaction { Buyer = users["admin"], Bottle = bottles["octo ao1"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["octo ao1"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["octo ao1"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["octo ao1"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["oban o2 drunk"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["oban o2 drunk"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["oban o2 drunk"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["oban o2 drunk"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["glenfiddich ao1o2"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["glenfiddich ao1o2"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["glenfiddich ao1o2"], CreationTime = new DateTime(2020, 12, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["glenfiddich ao1o2"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["glenfiddich ao1o2"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["glenfiddich o1o2"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["glenfiddich o1o2"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["glenfiddich o1o2"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["glenfiddich o1o2"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["glenfiddich o1o2"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["inactive_des ai"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["inactive_des ai"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["inactive_des ai"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["inactive_des ai"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["inactive_des ai"], CreationTime = new DateTime(2020, 11, 24) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["inactive_des o1"], CreationTime = new DateTime(2020, 11, 24) },

                new Transaction { Buyer = users["admin"], Bottle = bottles["octo ao1"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["talisker i"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["talisker i"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["talisker i"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["talisker i"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["talisker i"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["macallan a"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["macallan a"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["macallan a"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["macallan a"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["inactive_des o1"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["inactive_des o1"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },
                new Transaction { Buyer = users["admin"], Bottle = bottles["inactive_des o1"], CreationTime = new DateTime(2019, 12, 3), IsPayed = true, PaymentTime = new DateTime(2019, 12, 30) },

            };

            SetAmountsFor(transactions);
            SetPricesFor(transactions, specialPrices);
            ShiftCreationTimesFor(transactions);
            #endregion

            #region Filling DB
            foreach (var user in users.Values)
                userManager.CreateAsync(user, passwd).Wait();
            Console.WriteLine("  ... users filled");

            context.Tags
                .AddRange(tags.Values);
            Console.WriteLine("  ... tags filled");

            context.BottleDescriptions
                .AddRange(bottleDescriptions.Values);
            Console.WriteLine("  ... bottle descriptions filled");

            context.Bottles
                .AddRange(bottles.Values);
            Console.WriteLine("  ... bottles filled");

            context.SpecialPrices
                .AddRange(specialPrices);
            Console.WriteLine("  ... special prices filled");

            context.Transactions
                .AddRange(transactions);
            Console.WriteLine("  ... transactions filled");

            context.SaveChanges();
            #endregion
        }

        private static string GetPictureUrl()
            => "https://i.pinimg.com/originals/74/1e/7e/741e7e249e599a8c360dc459667c3407.jpg";

        private static void SetAmountsFor(List<Transaction> transactions)
        {
            foreach (var tr in transactions)
                tr.Amount_ml = 20;
        }

        private static void SetPricesFor(List<Transaction> transactions, List<SpecialPrice> specialPrices)
        {
            foreach (var tr in transactions)
            {
                if (tr.Bottle.Owners.Contains(tr.Buyer))
                    tr.Price = GetRealPriceFor(tr);
                else
                    tr.Price =
                        specialPrices.FirstOrDefault(sp => sp.User == tr.Buyer)?.Price ??
                        tr.Bottle.ShotPrice;
            }
        }

        private static void ShiftCreationTimesFor(List<Transaction> transactions)
        {
            int i = 0;
            foreach (var tr in transactions)
            {
                tr.CreationTime += new TimeSpan(hours: i, minutes: 0, seconds: 0);
                i++;
            }
        }

        private static decimal GetRealPriceFor(Transaction t)
        {
            const decimal shotSize = 20m;
            var bottle = t.Bottle;

            var realAmountInBottle = bottle.Amount_ml * (100 - bottle.WastePercent) / 100m;
            var numOfShots = realAmountInBottle / shotSize;
            var pricePerShot = bottle.BottlePrice / numOfShots;

            var numOfShotInTransaction = t.Amount_ml / shotSize;

            return Math.Round(pricePerShot * numOfShotInTransaction, decimals: 2);
        }

    }
}
