using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using WhiskyMan.Entities.Auth;

namespace WhiskyMan.Entities
{
    [Index(nameof(IsPayed), nameof(CreationTime), IsUnique = false)]
    [Index(nameof(CreationTime), IsUnique = false)]
    public record Transaction
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public User Buyer { get; set; }
        public long BuyerId { get; set; }

        [Required]
        public Bottle Bottle { get; set; }
        public long BottleId { get; set; }

        [Required]
        public int Amount_ml { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime CreationTime { get; set; } = DateTime.Now;
        
        [Required]
        public bool IsPayed { get; set; }
        public DateTime? PaymentTime { get; set; }
    }
}
