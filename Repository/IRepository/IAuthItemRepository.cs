using System;
using System.Collections.Generic;
using UserPrivileges.Models;

namespace UserPrivileges.Repository.IRepository
{
    public interface IAuthItemRepository
    {

        ICollection<AuthItem> GetAuthItems();


        bool CreateAuthItem(AuthItem authItem);

       
        bool AuthItemExists(string name);


        bool UpdateAuthItem(AuthItem authItem);

        bool DeleteAuthItem(AuthItem authItem); //This can be based on Id

        bool Save();
    }
}
