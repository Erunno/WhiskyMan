using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities.Auth;
using WhiskyMan.Repositories.Interfaces;
using WhiskyMan.Repositories.Interfaces.Wrappers;

namespace WhiskyMan.Repositories.DatabaseStartup
{
    public class UpdateRolesOperation
    {
        private readonly IRoleManagerWrapper roleManager;

        public UpdateRolesOperation(IRoleManagerWrapper roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task Run()
        {
            foreach (var field in typeof(Roles).GetFields())
            {
                var roleName = (string)field.GetValue(null);
                var roleIsInDB = await roleManager.RoleExistsAsync(roleName);

                if (!roleIsInDB)
                    await roleManager.CreateAsync(roleName);
            }
        }

    }
}
