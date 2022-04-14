using System;
using System.ComponentModel.DataAnnotations;

namespace UserPrivileges.Models
{
    public class AuthItem
    {
        [Key]
        public string PrivilegeName { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }
    }
}
