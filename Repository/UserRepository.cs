using System;
using System.Security.Cryptography;
using UserPrivileges.Data;
using UserPrivileges.Models;
using UserPrivileges.Repository.IRepository;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Linq;
using System.Collections.Generic;

namespace UserPrivileges.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICollection<User> GetUsers()
        {
            return _db.User.OrderBy(a => a.Email).ToList();
        }

        public bool ChangeUserPassword(User user)
        {
            _db.User.Update(user);
            return Save();
        }

        public bool CreateUser(User user)
        {
            _db.User.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _db.User.Update(user);
            return Save();
        }

        public bool Save()
        {
            return _db.SaveChanges() > 0 ? true : false;
        }

        public bool UpdateUser(User user)
        {
            _db.User.Update(user);
            return Save();
        }

        public bool UserExists(string email)
        {
            bool value = _db.User.Any(a => a.Email.ToLower().Trim() == email.ToLower().Trim());
            return value;
        }

        public bool UserIdExists(string Id)
        {
            return _db.User.Any(a => a.Id == Id);
        }


        public string EncryptUserPassword(string password)
        {
            // generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

    }
}
