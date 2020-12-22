using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyMan.Models.User
{
    public record UserReference
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
