using Microsoft.EntityFrameworkCore;
using UserPrivileges.Models;

namespace UserPrivileges.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }


        public DbSet<User> User { get; set; }
        public DbSet<AuthItem> AuthItems { get; set; }
        public DbSet<AuthItemChild> AuthItemChild { get; set; }
        public DbSet<UserPrivilege> UserPrivilege { get; set; }
        public DbSet<PackingRule> PackingRules { get; set; }
        public DbSet<PackingTickets> PackingTickets { get; set; }
    }

    
}
