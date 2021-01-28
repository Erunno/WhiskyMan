using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities.Auth;
using WhiskyMan.Repositories.Interfaces;
using WhiskyMan.Repositories.Interfaces.Wrappers;

namespace WhiskyMan.Repositories.Wrappers
{
    public class UserManagerWrapper : IUserManagerWrapper
    {
        private readonly UserManager<User> userManager;

        public UserManagerWrapper(
            UserManager<User> userManager
            )
        {
            this.userManager = userManager;
        }

        public Task<IdentityResult> CreateAsync(User user, string password)
            => userManager.CreateAsync(user, password);
    }
}
