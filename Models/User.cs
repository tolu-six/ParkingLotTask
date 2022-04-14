using System;
using System.ComponentModel.DataAnnotations;

namespace UserPrivileges.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Lastname { get; set; }

        [Required]
        [MaxLength(50)]
        public string Firstname { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime Created { get; set; }
    }
}
