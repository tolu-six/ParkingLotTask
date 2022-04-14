using System;
using System.Collections.Generic;
using UserPrivileges.Models;

namespace UserPrivileges.Repository.IRepository
{
    public interface IUserPrivilegeRepository
    {

        ICollection<UserPrivilege> GetUserPrivileges();


        bool CreateUserPrivilege(UserPrivilege userPrivilege);


        bool UserPrivilegeExists(string userid, string privilegeName);


        bool UpdateUserPrivilege(UserPrivilege userPrivilege);

        bool DeleteUserPrivilege(UserPrivilege userPrivilege); //This can be based on Id

        bool AssignUserPrivilege(string userId, string privilegeName);

        bool Save();

    }
}
