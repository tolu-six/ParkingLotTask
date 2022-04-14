using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserPrivileges.Models
{
    public class UserPrivilege
    {
        [Key]
        public int Id { get; set; }

        //[ForeignKey ("User")]
        public string UserId { get; set; }

        //[ForeignKey("UserPrivilege")]
        public string AuthItem { get; set; }

        public DateTime Created { get; set; }
    }
}
