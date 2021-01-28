using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;
using WhiskyMan.Entities.Auth;
using WhiskyMan.Models.User;
using WhiskyMan.Repositories.Mapping;

namespace WhiskyMan.Repositories.Tests.Mapping
{
    class UserMapsTest : MappingTest
    {

        [Test]
        public void User_UserModel()
        {
            // arrange

            var expected = GetUserModel();

            // act + assert
            var actual = TestMapping<User, UserModel>(
                input: GetUserEntityWithNoCollections(),
                expected: expected,

                // don't check following properties
                nameof(UserModel.Roles)
                );

            // additional assert
            CollectionAssert.AreEquivalent(expected.Roles, actual.Roles);
        }

        [Test]
        public void User_UserView()
            => TestMapping<User, UserView>(
                input: GetUserEntityWithNoCollections(),
                expected: GetUserView()
                );

        [Test]
        public void User_UserReference()
            => TestMapping<User, UserReference>(
                input: GetUserEntityWithNoCollections(),
                expected: GetUserReference()
                );

        [Test]
        public void UserForRegister_User()
            => TestMapping<UserForRegister, User>(
                input: GetUserForRegister(),
                expected: GetUserEntityWithNoCollections(),

                // don't check following properties
                nameof(User.Id),
                nameof(User.ConcurrencyStamp)
                );
        
        private User GetUserEntityWithNoCollections()
            => new User
            {
                Id = 1,
                UserName = "testoslav",
                FirstName = "Zdibrich",
                LastName = "Smith",
                Email = "zdibrich@email.cz",
                PictureUrl = "url.com",
                Active = true,
                Roles = new List<Role> { new Role { Name = "testRole" }, new Role { Name = "anotherTestRole" } }
            };
        
        private UserModel GetUserModel()
            => new UserModel
            {
                Id = 1,
                UserName = "testoslav",
                FirstName = "Zdibrich",
                LastName = "Smith",
                Email = "zdibrich@email.cz",
                PictureUrl = "url.com",
                Roles = new List<string> { "testRole", "anotherTestRole" }
            };

        private UserForRegister GetUserForRegister()
            => new UserForRegister
            {
                UserName = "testoslav",
                FirstName = "Zdibrich",
                LastName = "Smith",
                Email = "zdibrich@email.cz",
                PictureUrl = "url.com",
                Password = "trouba-69"
            };

        private UserView GetUserView()
            => new UserView
            {
                Id = 1,
                FullName = "Zdibrich Smith",
                PictureUrl = "url.com"
            };

        private UserReference GetUserReference()
            => new UserReference
            {
                Id = 1,
                Name = "Zdibrich Smith",
            };
    }
}
