using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Models.User;
using WhiskyMan.Repositories.Interfaces;
using WhiskyMan.Repositories.Interfaces.Wrappers;

namespace WhiskyMan.BusinessLogic.Authentication
{
    public class AuthService
    {
        private readonly IUserRepository repo;
        private readonly IConfiguration config;
        private readonly ISignInManagerWrapper signInManager;
        private readonly IMapper mapper;

        public AuthService(
            IUserRepository repo,
            IConfiguration config,
            ISignInManagerWrapper signInManager,
            IMapper mapper)
        {
            this.repo = repo;
            this.config = config;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        /// <summary>
        /// Checks username-password combination and return token if input is correct null otherwise.
        /// </summary>
        public async Task<SecurityToken> GetTokenFor(UserForLogin userForLogin, int validDays)
        {
            var result = await signInManager.CheckPasswordSignInAsync(
                userForLogin.UserName,
                userForLogin.Password,
                lockoutOnFailure: false);

            if (!result.Succeeded)
                return null;

            return await GenerateToken(userForLogin.UserName, validDays);
        }

        public Task<IdentityResult> Register(UserForRegister userForRegister)
            => repo.AddUser(userForRegister);

        private async Task<SecurityToken> GenerateToken(string username, int validDays)
        {
            var user = await repo.GetUser(username);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };

            foreach (var role in user.Roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(config.GetSection("AppSettings:Token").Value));

            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(validDays),
                SigningCredentials = cred
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.CreateToken(tokenDescriptor);
        }
    }
}
