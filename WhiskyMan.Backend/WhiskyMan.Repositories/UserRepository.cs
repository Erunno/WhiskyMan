using AutoMapper;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;
using WhiskyMan.Models.User;
using Microsoft.EntityFrameworkCore;

namespace WhiskyMan.Repositories.Interfaces
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataContextWrapper context;
        private readonly IMapper mapper;

        public UserRepository(
            IDataContextWrapper context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<UserModel> AddUser(UserForAuthModel user)
        {
            var entityEntry = await context.AddEntityAsync(mapper.Map<User>(user));
            await context.SaveChangesAsync();
            return entityEntry != null ? mapper.Map<UserModel>(entityEntry.Entity) : null;
        }

        public async Task<UserModel> GetUser(int userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(user => user.Id == userId);
            return user != null ? mapper.Map<UserModel>(user) : null;
        }

        public async Task<UserForAuthModel> GetUserForAuth(string username)
        {
            var user = await context.Users.FirstOrDefaultAsync(user => user.Username == username);
            return user != null ? mapper.Map<UserForAuthModel>(user) : null;
        }

        public async Task<UserView> GetUserView(string username)
        {
            var user = await context.Users.FirstOrDefaultAsync(user => user.Username == username);
            return mapper.Map<UserView>(user);
        }

        public Task<bool> UserExistsByUsername(string username)
            => context.Users.AnyAsync(user => user.Username == username);
    }
}
