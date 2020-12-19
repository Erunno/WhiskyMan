using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;
using WhiskyMan.Models.User;
using WhiskyMan.Repositories.Mapping;

namespace WhiskyMan.Repositories.Tests.Mapping
{
    class UserMapsTest : MappingTest
    {

        [Test]
        public void User_UserModel()
            => TestMapping<User, UserModel>(
                input: GetUserEntityWithNoCollections(),
                expected: GetUserModel()
                );

        [Test]
        public void User_UserView()
            => TestMapping<User, UserView>(
                input: GetUserEntityWithNoCollections(),
                expected: GetUserView()
                );

        [Test]
        public void User_ForAuthModel()
            => TestMapping<User, UserForAuthModel>(
                input: GetUserEntityWithNoCollections(),
                expected: GetUserForAuthModel(),
                
                // don't check following properties
                nameof(UserForAuthModel.PasswordHash),
                nameof(UserForAuthModel.PasswordSalt)
                );

        [Test]
        public void UserForRegister_UserForAuthModel()
            => TestMapping<UserForRegister, UserForAuthModel>(
                input: GetUserForRegister(),
                expected: GetUserForAuthModel(),
                
                // don't check following properties
                nameof(UserForAuthModel.PasswordHash),
                nameof(UserForAuthModel.PasswordSalt),
                nameof(UserForAuthModel.Id)
                );

        [Test]
        public void UserForAuthModel_User()
            => TestMapping<UserForAuthModel, User>(
                input: GetUserForAuthModel(),
                expected: GetUserEntityWithNoCollections(),
                
                // don't check following properties
                nameof(User.PasswordHash),
                nameof(User.PasswordSalt)
                );

        private User GetUserEntityWithNoCollections()
            => new User
            {
                Id = 1,
                Username = "testoslav",
                FirstName = "Zdibrich",
                LastName = "Smith",
                Email = "zdibrich@email.cz",
                PictureUrl = "url.com",
            };
        
        private UserForAuthModel GetUserForAuthModel()
            => new UserForAuthModel
            {
                Id = 1,
                Username = "testoslav",
                FirstName = "Zdibrich",
                LastName = "Smith",
                Email = "zdibrich@email.cz",
                PictureUrl = "url.com"
            };

        private UserModel GetUserModel()
            => new UserModel
            {
                Id = 1,
                Username = "testoslav",
                FirstName = "Zdibrich",
                LastName = "Smith",
                Email = "zdibrich@email.cz",
                PictureUrl = "url.com"
            };

        private UserForRegister GetUserForRegister()
            => new UserForRegister
            {
                Username = "testoslav",
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
    }
}
