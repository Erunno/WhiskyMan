using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyMan.Repositories.Interfaces.Wrappers
{
    public interface IRoleManagerWrapper
    {
        public Task<bool> RoleExistsAsync(string name);
        public Task CreateAsync(string name);
    }
}
