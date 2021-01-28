using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyMan.Models.Bottle
{
    public record BottleView
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal ShotPrice { get; set; }
        public string Distillery { get; set; }
        public string PictureUrl { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Owners { get; set; }
    }
}
