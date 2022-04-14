using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserPrivileges.Models
{
    public class AuthItemChild
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AuthItem")]
        public string AuthItemName { get; set; }

        [Required]
        [MaxLength(50)]
        public string PrivilegeChildName { get; set; }

        public string Description { get; set; }

        public DateTime Created { get; set; }
    }
}
