using System;
using System.Collections.Generic;
using UserPrivileges.Models;

namespace UserPrivileges.Repository.IRepository
{
    public interface IUserRepository
    {


        bool ChangeUserPassword(User user);


        bool CreateUser(User user);


        bool UserExists(string email);


        ICollection<User> GetUsers();


        bool UpdateUser(User user);


        bool DeleteUser(User user); //This can be based on Id

        string EncryptUserPassword(string password);


        bool Save();

    }
}
