using System;
using System.Collections.Generic;
using System.Text;

namespace WhiskyMan.Models.Dtos.User
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
}
