using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities.Auth;

namespace WhiskyMan.Entities
{
    [Index(nameof(BottleId), nameof(UserId), IsUnique = false)]
    [Index(nameof(UserId), nameof(BottleId), IsUnique = false)]
    public record SpecialPrice
    {
        [Required]
        public decimal Price { get; set; }

        // primary key is Bottle and User

        [Required]
        public Bottle Bottle { get; set; }
        public long BottleId { get; set; }

        [Required]
        public User User { get; set; }
        public long UserId { get; set; }
    }
}
