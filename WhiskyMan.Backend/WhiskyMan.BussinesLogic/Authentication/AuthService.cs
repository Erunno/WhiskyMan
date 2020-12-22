using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Models.User;
using WhiskyMan.Repositories.Interfaces;

namespace WhiskyMan.BusinessLogic.Authentication
{
    public class AuthService
    {
        private readonly IUserRepository repo;
        private readonly IConfiguration config;
        private readonly IMapper mapper;

        public AuthService(
            IUserRepository repo,
            IConfiguration config,
            IMapper mapper)
        {
            this.repo = repo;
            this.config = config;
            this.mapper = mapper;
        }


        public async Task<UserModel> Login(string username, string password)
        {
            var user = await repo.GetUserForAuth(username);

            if (user == null) return null;

            if (!VerifyPassword(password, user))
                return null;

            return await repo.GetUser(user.Id);
        }

        private bool VerifyPassword(string password, UserForAuthModel user)
        {
            using (var hmac = new HMACSHA512(user.PasswordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                var computedHashString = Encoding.UTF8.GetString(computedHash);

                if (user.PasswordHash.Length != computedHash.Length)
                    return false;

                for (int i = 0; i < computedHash.Length; i++)
                    if (computedHash[i] != user.PasswordHash[i])
                        return false;

                return true;
            }
        }

        public Task<UserModel> Register(UserForRegister userDto)
        {
            var user = mapper.Map<UserForAuthModel>(userDto);

            byte[] passwdHash, passwdSalt;
            CreatePasswordHash(userDto.Password, out passwdHash, out passwdSalt);

            user.PasswordHash = passwdHash;
            user.PasswordSalt = passwdSalt;

            return repo.AddUser(user);
        }

        private void CreatePasswordHash(string password, out byte[] passwdHash, out byte[] passwdSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwdSalt = hmac.Key;
                passwdHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<SecurityToken> GenerateToken(int userId, int validDays)
        {
            var user = await repo.GetUser(userId);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            };

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
