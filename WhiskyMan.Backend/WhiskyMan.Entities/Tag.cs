using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyMan.Entities
{
    [Index(nameof(Active), nameof(Id), IsUnique = false)]
    public record Tag
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(EntitiesConfig.NameLength)]
        public string Name { get; set; }

        [Required]
        public bool Active { get; set; } = true;

        public ICollection<BottleDescription> BottleDescriptions { get; set; }
    }
}
