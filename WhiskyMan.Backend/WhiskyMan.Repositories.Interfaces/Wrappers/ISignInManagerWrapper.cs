using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities.Auth;

namespace WhiskyMan.Repositories.Interfaces.Wrappers
{
    public interface ISignInManagerWrapper
    {
        Task<SignInResult> CheckPasswordSignInAsync(string username, string password, bool lockoutOnFailure);
    }
}
