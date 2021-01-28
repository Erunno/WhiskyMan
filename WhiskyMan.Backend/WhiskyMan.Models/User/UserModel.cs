using System;
using System.Collections.Generic;

namespace WhiskyMan.Models.User
{
    public record UserModel
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PictureUrl { get; set; }
        public List<string> Roles { get; set; }
    }
}
