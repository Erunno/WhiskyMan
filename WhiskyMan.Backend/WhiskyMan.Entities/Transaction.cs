﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WhiskyMan.Entities
{
    public record Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public User Buyer { get; set; }
        public int BuyerId { get; set; }

        [Required]
        public Bottle Bottle { get; set; }
        public int BottleId { get; set; }

        [Required]
        public int Amount_ml { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
        
        [Required]
        public bool IsPayed { get; set; }
        public DateTime PaymentTime { get; set; }
    }
}
