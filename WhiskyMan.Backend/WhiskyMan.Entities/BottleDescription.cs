using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Collections.Generic;

namespace WhiskyMan.Entities
{
    [Index(nameof(Active), nameof(Id), IsUnique = false)]
    public record BottleDescription
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [MaxLength(EntitiesConfig.NameLength)]
        public string Name { get; set; }
        [Required]
        [MaxLength(EntitiesConfig.NameLength)]
        public string Distillery { get; set; }
        public int Age { get; set; }
        public decimal Voltage { get; set; }
        [Required]
        [MaxLength(EntitiesConfig.UrlLength)]
        public string PictureUrl { get; set; }
        [Required]
        [MaxLength(EntitiesConfig.DescriptionLength)]
        public string DescriptionText { get; set; }
        [MaxLength(EntitiesConfig.NameLength)]
        public string Region { get; set; }
        [Required]
        public bool Active { get; set; }

        public ICollection<Bottle> Bottles { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
