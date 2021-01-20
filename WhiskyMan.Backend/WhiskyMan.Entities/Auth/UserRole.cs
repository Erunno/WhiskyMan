using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyMan.Entities.Auth
{
    public class UserRole : IdentityUserRole<long>
    {
        public User User { get; set; }

        public Role Role { get; set; }
    }
}
