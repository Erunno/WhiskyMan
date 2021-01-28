using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
    public class SignInManagerWrapper : ISignInManagerWrapper
    {
        private readonly SignInManager<User> signInManager;
        private readonly IDataContextWrapper dataContext;

        public SignInManagerWrapper(
            SignInManager<User> signInManager,
            IDataContextWrapper dataContext
            )
        {
            this.signInManager = signInManager;
            this.dataContext = dataContext;
        }

        public async Task<SignInResult> CheckPasswordSignInAsync(string username, string password, bool lockoutOnFailure)
        {
            var usernameLower = username.ToLower();
            var user = await dataContext.Users
                .SingleOrDefaultAsync(u => u.UserName == usernameLower);

            return await signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure);
        }
    }
}
