using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyMan.Models.Bottle
{
    public record SpecialPriceInBottleModel
    {
        public long UserId { get; set; }
        public decimal Price { get; set; }
    }
}
