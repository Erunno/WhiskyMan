using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
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

        [Authorize]
        [HttpGet("user-view/{id}")]
        public async Task<IActionResult> GetUserView(int id) 
            => Ok(await repo.GetUserView(User.Identity.Name));

    }
}
