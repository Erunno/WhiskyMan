using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using WhiskyMan.BusinessLogic.Authentication;
using WhiskyMan.Models.User;
using WhiskyMan.Repositories.Interfaces;

namespace WhiskyMan.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService authSevice;
        private readonly IUserRepository userRepo;

        public AuthController(AuthService authSevice, IUserRepository userRepo)
        {
            this.authSevice = authSevice;
            this.userRepo = userRepo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegister userDto)
        {
            userDto.Username = userDto.Username.ToLower();

            if (await userRepo.UserExistsByUsername(userDto.Username))
                return BadRequest("Username already exists");

            await authSevice.Register(userDto);
            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLogin userDto)
        {
            var user = await authSevice.Login(userDto.Username.ToLower(), userDto.Password);

            if (user == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await authSevice.GenerateToken(user.Id, validDays: 30);

            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
    }
}
