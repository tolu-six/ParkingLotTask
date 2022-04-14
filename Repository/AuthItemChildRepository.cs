using System;
using System.Collections.Generic;
using System.Linq;
using UserPrivileges.Data;
using UserPrivileges.Models;
using UserPrivileges.Repository.IRepository;

namespace UserPrivileges.Repository
{
    public class AuthItemChildRepository : IAuthItemChildRepository
    {
        private readonly ApplicationDbContext _db;

        public AuthItemChildRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool AuthItemChildExists(string name)
        {
            bool value = _db.AuthItemChild.Any(a => a.PrivilegeChildName.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool CreateAuthItemChild(AuthItemChild authItemChild)
        {
            if (!this.AuthItemChildExists(authItemChild.PrivilegeChildName))
            {
                _db.AuthItemChild.Add(authItemChild);
                return Save();
            }

            throw new Exception("There can't be duplicated child privilege");
        }

        public bool DeleteAuthItemChild(AuthItemChild authItemChild)
        {
            if (!this.AuthItemChildExists(authItemChild.PrivilegeChildName))
            {
                throw new Exception("Priviledge Name cannot be found");
            }

            _db.AuthItemChild.Remove(authItemChild);
            return Save();
        }

        public ICollection<AuthItem> GetAuthItemsChild()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateAuthItemChild(AuthItemChild authItemChild)
        {
            _db.AuthItemChild.Update(authItemChild);
            return Save();
        }
    }
}
