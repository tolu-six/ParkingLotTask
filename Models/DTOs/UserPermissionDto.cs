using System;
using System.ComponentModel.DataAnnotations;

namespace UserPrivileges.Models.DTOs
{
    public class UserPermissionDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string PermissioName { get; set; }
    }
}
