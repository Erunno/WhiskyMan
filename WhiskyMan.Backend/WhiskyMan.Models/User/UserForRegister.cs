using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using WhiskyMan.Entities;

namespace WhiskyMan.Models.User
{
    public class UserForRegister
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PictureUrl { get; set; }
    }

    public class Validator_UserForRegister : AbstractValidator<UserForRegister>
    {
        public Validator_UserForRegister()
        {
            RuleFor(x => x.Username).NotNull().Length(3, EntitiesConfig.NameLength);
            RuleFor(x => x.FirstName).NotNull().Length(2, EntitiesConfig.NameLength);
            RuleFor(x => x.LastName).NotNull().Length(2, EntitiesConfig.NameLength);
            RuleFor(x => x.Email).NotNull().EmailAddress().Length(3, EntitiesConfig.EmailLength);
            RuleFor(x => x.Password).NotNull().Length(3, EntitiesConfig.PasswdLength);
        }
    }
}
