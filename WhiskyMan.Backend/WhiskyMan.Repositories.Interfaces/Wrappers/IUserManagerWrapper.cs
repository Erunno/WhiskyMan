using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities.Auth;

namespace WhiskyMan.Repositories.Interfaces.Wrappers
{
    public interface IUserManagerWrapper
    {
        Task<IdentityResult> CreateAsync(User user, string password);
        Task<IdentityResult> AddToRoleAsync(User user, string role);
        IQueryable<User> Users { get; }
    }
}
