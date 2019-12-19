using EdirDataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdirDataAccess
{
    public class EdirDbContext:DbContext
    {
        public EdirDbContext()
        {
            
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Attendace> Attendances { get; set; }
        public DbSet<Child> Childs { get; set; }
        public DbSet<EdirEvent> EdirEvents { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<Loss> Losses { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberRole> MemberRoles { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Rule> Rules { get; set; }
        public DbSet<Sibling> Siblings { get; set; }
        public DbSet<Spouse> spouses { get; set; }
        public DbSet<SpouseSibling> SpouseSiblings { get; set; }
       
    }
}
