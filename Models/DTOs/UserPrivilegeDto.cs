using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserPrivileges.Models.DTOs
{
    public class UserPrivilegeDto
    {

        [ForeignKey("User")]
        public string UserId { get; set; }

        //[ForeignKey("UserPrivilege")]
        public string AuthItem { get; set; }
    }
}
