using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WhiskyMan.BusinessLogic.Policy.Users;
using WhiskyMan.Entities.Auth;
using WhiskyMan.Models.User;
using WhiskyMan.Repositories.Interfaces;

namespace WhiskyMan.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository repo;

        public UsersController(
            IUserRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet("user-view/{id}")]
        [Authorize(Policy = UserPolicies.ViewOwnUserInfo)]
        public async Task<IActionResult> GetUserView(int id) 
            => Ok(await repo.GetUserView(User.Identity.Name));

        [HttpGet("active-references")]
        [Authorize(Roles = Roles.Customer)]
        public async Task<IActionResult> GetUserReferences()
            => Ok(await repo.GetActiveUserReferences());

    }
}
