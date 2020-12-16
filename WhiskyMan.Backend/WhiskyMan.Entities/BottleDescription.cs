﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WhiskyMan.Entities
{
    public class BottleDescription
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Distillery { get; set; }
        public int Age { get; set; }
        public decimal Voltage { get; set; }
        [Required]
        [MaxLength(300)]
        public string PictureUrl { get; set; }

        public Collection<Bottle> Bottles { get; set; }
    }
}