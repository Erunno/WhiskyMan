using AutoMapper;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;
using WhiskyMan.Models.User;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using WhiskyMan.Entities.Auth;
using Microsoft.AspNetCore.Identity;
using WhiskyMan.Repositories.Interfaces.Wrappers;

namespace WhiskyMan.Repositories.Interfaces
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataContextWrapper context;
        private readonly IUserManagerWrapper userManager;
        private readonly IMapper mapper;

        public UserRepository(
            IDataContextWrapper context,
            IUserManagerWrapper userManager,
            IMapper mapper)
        {
            this.context = context;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<IdentityResult> AddUser(UserForRegister user)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                var userEntity = mapper.Map<User>(user);
                var result = await userManager.CreateAsync(userEntity, user.Password);

                if (result.Succeeded)
                    result = await userManager.AddToRoleAsync(userEntity, Roles.Customer);

                if (result.Succeeded)
                    transaction.Commit();

                return result;
            }
        }

        public Task<List<UserReference>> GetActiveUserReferences()
            => context.Users
                .Where(user => user.Active)
                .ProjectTo<UserReference>(mapper.ConfigurationProvider)
                .ToListAsync();

        public async Task<UserModel> GetUser(long userId)
        {
            var user = await context.Users.FirstOrDefaultAsync(user => user.Id == userId);
            return user != null ? mapper.Map<UserModel>(user) : null;
        }

        public async Task<UserModel> GetUser(string username)
        {
            var usernameLower = username.ToLower();
            var user = await userManager.Users
                .Include(user => user.Roles)
                .SingleOrDefaultAsync(u => u.UserName == usernameLower);

            return user != null ? mapper.Map<UserModel>(user) : null;
        }

        public async Task<UserView> GetUserView(string username)
        {
            var user = await context.Users.FirstOrDefaultAsync(user => user.UserName == username);
            return mapper.Map<UserView>(user);
        }

        public Task<bool> UserExistsByUsername(string username)
            => context.Users.AnyAsync(user => user.UserName == username);
    }
}
