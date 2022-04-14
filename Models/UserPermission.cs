using System;
using System.ComponentModel.DataAnnotations;

namespace UserPrivileges.Models
{
    public class UserPermission
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string PermissioName { get; set; }

        public DateTime Created { get; set; }
    }
}
