using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyMan.Models.BottleDescription
{
    public record TagReference
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
