using Autofac;
using Autofac.Core;
using Autofac.Core.Activators.Reflection;
using Autofac.Extras.Moq;
using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiskyMan.Entities;
using WhiskyMan.Models.User;
using WhiskyMan.Repositories.Interfaces;
using WhiskyMan.Repositories.Mapping;

namespace WhiskyMan.Repositories.Tests
{
    public class UserRepositoryTest
    {
        public List<User> GetUsers()
        {
            return new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Username = "trouba1"
                },
                new User()
                {
                    Id = 2,
                    Username = "trouba2"
                },
                new User()
                {
                    Id = 3,
                    Username = "trouba3"
                }
            };
        }

        [Test]
        public async Task AddUser_ValidUser_ShouldBeSaved()
        {
            using(var mock = AutoMock.GetStrict(builder =>
                builder.RegisterType<MapperForTesting>().As<IMapper>()
            ))
            {
                // arrange
                var context = mock.Mock<IDataContextWrapper>();
                context
                    .Setup(c => c.AddEntityAsync(It.IsAny<User>()))
                    .Returns(null);
                context
                    .Setup(c => c.SaveChangesAsync())
                    .Returns(Task.FromResult(0));

                var userToAdd = new UserForAuthModel { Id = 1, Username = "trouba" };
                var repo = mock.Create<UserRepository>();

                // act
                var addedUser = await repo.AddUser(userToAdd);

                // assert
                Assert.Multiple(() =>
                {
                    context.Verify(c => c.SaveChangesAsync(), Times.Once);
                    context.Verify(c => c.AddEntityAsync(It.IsAny<User>()), Times.Once);
                });
            }
        }
    }
}