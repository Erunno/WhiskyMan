using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WhiskyMan.Entities
{
    public record BottleDescription
    {
        [Key]
        public int Id { get; set; }

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

        public Collection<Bottle> Bottles { get; set; }
    }
}
