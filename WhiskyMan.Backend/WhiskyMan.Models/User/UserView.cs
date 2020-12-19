using System;
using System.Collections.Generic;
using System.Text;

namespace WhiskyMan.Models.User
{
    public record UserView
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PictureUrl { get; set; }
    }
}
