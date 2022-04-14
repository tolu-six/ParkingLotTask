using System;
using System.Collections.Generic;
using UserPrivileges.Models;

namespace UserPrivileges.Repository.IRepository
{
    public interface IAuthItemChildRepository
    {
        ICollection<AuthItem> GetAuthItemsChild();


        bool CreateAuthItemChild(AuthItemChild authItemChild);


        bool AuthItemChildExists(string name);


        bool UpdateAuthItemChild(AuthItemChild authItemChild);

        bool DeleteAuthItemChild(AuthItemChild authItemChild); //This can be based on Id

        bool Save();

    }
}
