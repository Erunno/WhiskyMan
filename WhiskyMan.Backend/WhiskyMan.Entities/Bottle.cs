using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using WhiskyMan.Entities.Auth;

namespace WhiskyMan.Entities
{
    [Index(nameof(IsDrunk), IsUnique = false)]
    public record Bottle
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public BottleDescription BottleDescription { get; set; }
        public long BottleDescriptionId { get; set; }

        [Required]
        public int Amount_ml { get; set; }
        [Required]
        public decimal ShotPrice { get; set; }
        [Required]
        public decimal BottlePrice { get; set; }
        [Required]
        public bool IsDrunk { get; set; }
        [Required]
        public int WastePercent { get; set; }

        public ICollection<User> Owners { get; set; }
        public ICollection<Ownership> Ownerships { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<SpecialPrice> SpecialPrices { get; set; }
    }
}
