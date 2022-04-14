using System;
using System.ComponentModel.DataAnnotations;

namespace UserPrivileges.Models.DTOs
{
    public class AuthItemDto
    {
        [Key]
        public string PrivilegeName { get; set; }

        public string Description { get; set; }
    }
}
