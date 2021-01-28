using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhiskyMan.Entities.Auth
{
    [Index(nameof(UserName), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Active), nameof(Id), IsUnique = false)]
    public class User : IdentityUser<long>
    {
        [Required]
        [MaxLength(EntitiesConfig.NameLength)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(EntitiesConfig.NameLength)]
        public string LastName { get; set; }
        [MaxLength(EntitiesConfig.UrlLength)]
        public string PictureUrl { get; set; }
        [Required]
        public bool Active { get; set; } = true;

        public ICollection<Bottle> Bottles { get; set; }
        public ICollection<Ownership> Ownerships { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<SpecialPrice> SpecialPrices { get; set; }

        public ICollection<Role> Roles { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}
