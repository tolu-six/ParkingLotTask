using System;
using System.ComponentModel.DataAnnotations;

namespace UserPrivileges.Models.DTOs
{
    public class UserDto
    {
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

        [Required]
        public string PrivilegeName { get; set; }
    }
}
