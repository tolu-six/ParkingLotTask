using System;
using System.Collections.Generic;
using System.Linq;
using UserPrivileges.Data;
using UserPrivileges.Models;
using UserPrivileges.Repository.IRepository;

namespace UserPrivileges.Repository
{
    public class UserPrivilegeRepository : IUserPrivilegeRepository
    {
        private readonly ApplicationDbContext _db;


        public UserPrivilegeRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public bool CreateUserPrivilege(UserPrivilege userPrivilege)
        {
            _db.UserPrivilege.Add(userPrivilege);
            return Save();
        }

        public bool DeleteUserPrivilege(UserPrivilege userPrivilege)
        {
            _db.UserPrivilege.Remove(userPrivilege);
            return Save();
        }

        public ICollection<UserPrivilege> GetUserPrivileges()
        {
            return _db.UserPrivilege.OrderBy(a => a.AuthItem).ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateUserPrivilege(UserPrivilege userPrivilege)
        {
            _db.UserPrivilege.Update(userPrivilege);
            return Save();
        }


        public bool UserPrivilegeExists(string userid, string privilegeName)
        {
            bool userRole = _db.UserPrivilege.Any(
                a => a.AuthItem.ToLower().Trim() == privilegeName.ToLower().Trim() &&
                a.UserId == userid
                );
            return userRole;
        }

        private bool CheckRoleExists(string role)
        {
            bool createdRole = _db.AuthItems.Any(x => x.PrivilegeName.ToLower().Trim() == role.ToLower().Trim());
            return createdRole; ;
        }


        public bool AssignUserPrivilege(string userId, string privilegeName)
        {

            if (!this.CheckRoleExists(privilegeName))
            {
                throw new NotSupportedException($"{privilegeName} does not exists, Contact Administrator!");
            }


            if(this.UserPrivilegeExists(userId, privilegeName))
            {
                throw new NotSupportedException($"{privilegeName} role has been assigned to user, Contact Administrator!");
            }


            var assign = new UserPrivilege
            {
                UserId = userId,
                AuthItem = privilegeName
            };

            _db.UserPrivilege.Add(assign);
            return Save();

        }

    }
}