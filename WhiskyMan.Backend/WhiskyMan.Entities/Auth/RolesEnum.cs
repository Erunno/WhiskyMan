using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyMan.Entities.Auth
{
    public static class Roles
    {
        // All roles used in the applications have to be registered here (as constants)
        // Also this class cannot have other fields since reflection is used to update DB during startup (see docs - https://github.com/Erunno/WhiskyMan/wiki/Managing-roles-in-C%23-app)

        public const string Admin = "admin";
        public const string Owner = "owner";
        public const string Customer = "customer";
    }
}
    