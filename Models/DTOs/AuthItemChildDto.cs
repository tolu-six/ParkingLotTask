using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserPrivileges.Models.DTOs
{
    public class AuthItemChildDto
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("AuthItem")]
        public int AuthItemId { get; set; }

        [Required]
        [MaxLength(50)]
        public string PrivilegeChildName { get; set; }

        public string Description { get; set; }
    }
}
