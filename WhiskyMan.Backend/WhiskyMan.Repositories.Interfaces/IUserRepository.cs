using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiskyMan.Models.User;

namespace WhiskyMan.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> GetUser(long userId);
        Task<UserModel> GetUser(string username);
        Task<IdentityResult> AddUser(UserForRegister user);
        Task<bool> UserExistsByUsername(string username);
        Task<UserView> GetUserView(string username);
        Task<List<UserReference>> GetActiveUserReferences();
    }
}
