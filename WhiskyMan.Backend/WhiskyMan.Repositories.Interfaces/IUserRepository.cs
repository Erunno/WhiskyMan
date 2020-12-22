using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WhiskyMan.Models.User;

namespace WhiskyMan.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserForAuthModel> GetUserForAuth(string username);
        Task<UserModel> GetUser(int userId);
        Task<UserModel> AddUser(UserForAuthModel user);
        Task<bool> UserExistsByUsername(string username);
        Task<UserView> GetUserView(string username);
        Task<List<UserReference>> GetActiveUserReferences();
    }
}
