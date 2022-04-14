using System;
using System.Collections.Generic;
using UserPrivileges.Data;
using UserPrivileges.Models;
using System.Linq;
using UserPrivileges.Repository.IRepository;

namespace UserPrivileges.Repository
{
    public class AuthItemRepository : IAuthItemRepository
    {
        private readonly ApplicationDbContext _db;

        public AuthItemRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool AuthItemExists(string name)
        {
            bool value = _db.AuthItems.Any(a => a.PrivilegeName.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool CreateAuthItem(AuthItem authItem)
        {
            _db.AuthItems.Add(authItem);
            return Save();
        }

        public bool DeleteAuthItem(AuthItem authItem)
        {
            if (!this.AuthItemExists(authItem.PrivilegeName))
            {
                throw new Exception("Priviledge Name cannot be found");
            }

            _db.AuthItems.Remove(authItem);
            return Save();
        }

        public ICollection<AuthItem> GetAuthItems()
        {
            return _db.AuthItems.OrderBy(a => a.PrivilegeName).ToList();
        }


        public bool Save()
        {
            return _db.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateAuthItem(AuthItem authItem)
        {
            _db.AuthItems.Update(authItem);
            return Save();
        }
    }
}
