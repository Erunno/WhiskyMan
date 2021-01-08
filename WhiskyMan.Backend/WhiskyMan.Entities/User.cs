using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhiskyMan.Entities
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Active), nameof(Id), IsUnique = false)]
    public record User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(EntitiesConfig.NameLength)]
        public string Username { get; set; }
        [Required]
        [MaxLength(EntitiesConfig.NameLength)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(EntitiesConfig.NameLength)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(EntitiesConfig.EmailLength)]
        public string Email { get; set; }
        [MaxLength(EntitiesConfig.UrlLength)]
        public string PictureUrl { get; set; }
        [Required]
        public bool Active { get; set; }

        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public ICollection<Bottle> Bottles { get; set; }
        public ICollection<Ownership> Ownerships { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<SpecialPrice> SpecialPrices { get; set; }
    }
}
