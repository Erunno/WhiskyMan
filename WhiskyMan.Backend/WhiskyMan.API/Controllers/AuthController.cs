using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using WhiskyMan.BusinessLogic.Authentication;
using WhiskyMan.Entities.Auth;
using WhiskyMan.Models.User;
using WhiskyMan.Repositories.Interfaces;

namespace WhiskyMan.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService authService;
        private readonly IUserRepository userRepo;
        private readonly IMapper mapper;

        public AuthController(
            AuthService authService,
            IUserRepository userRepo,
            IMapper mapper)
        {
            this.authService = authService;
            this.userRepo = userRepo;
            this.mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegister userDto)
        {
            userDto.UserName = userDto.UserName.ToLower();

            if (await userRepo.UserExistsByUsername(userDto.UserName))
                return BadRequest($"User with username '{userDto.UserName}' already exists");

            var result = await authService.Register(userDto);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return StatusCode(201);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserForLogin userDto)
        {
            var token = await authService.GetTokenFor(userDto, validDays: 30);

            if (token == null)
                return Unauthorized();

            var tokenHandler = new JwtSecurityTokenHandler();
            return Ok(new { token = tokenHandler.WriteToken(token) });
        }
    }
}
