using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyMan.Models.BottleDescription
{
    public record BottleDescriptionReference
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
    }
}
