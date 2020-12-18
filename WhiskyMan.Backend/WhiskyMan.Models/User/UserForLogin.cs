using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WhiskyMan.Entities;

namespace WhiskyMan.Models.User
{
    public class UserForLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Validator_UserForLogin : AbstractValidator<UserForLogin>
    {
        public Validator_UserForLogin()
        {
            RuleFor(x => x.Username).NotNull().Length(3, EntitiesConfig.NameLength);
            RuleFor(x => x.Password).NotNull().Length(3, EntitiesConfig.PasswdLength);
        }
    }
}
