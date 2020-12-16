using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WhiskyMan.Entities
{
    [Index(nameof(Username), IsUnique = true)]
    [Index(nameof(Email), IsUnique = true)]
    public class User
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
        [Required]
        [MaxLength(EntitiesConfig.UrlLength)]
        public string PictureUrl { get; set; }

        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

        public Collection<Bottle> Bottles { get; set; }
        public Collection<Transaction> Transactions { get; set; }
    }
}
