using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities.Auth;
using WhiskyMan.Repositories.Interfaces.Wrappers;

namespace WhiskyMan.Repositories.Wrappers
{
    public class RoleManagerWrapper : IRoleManagerWrapper
    {
        private readonly RoleManager<Role> roleManager;

        public RoleManagerWrapper(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
        }

        public Task<bool> RoleExistsAsync(string name)
            => roleManager.RoleExistsAsync(name);

        public Task CreateAsync(string name)
            => roleManager.CreateAsync(new Role { Name = name });

    }
}
