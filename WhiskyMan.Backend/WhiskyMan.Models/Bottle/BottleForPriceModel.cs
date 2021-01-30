using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyMan.Models.Bottle
{
    public record BottleForPriceModel
    {
        public List<long> Owners { get; set; }
        public List<SpecialPriceInBottleModel> SpecialPrices { get; set; }
        public decimal ShotPrice { get; set; }
        public decimal BottlePrice { get; set; }
        public int WastePercent { get; set; }
        public int Amount_ml { get; set; }
    }
}
