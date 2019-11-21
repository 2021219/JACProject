using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace JACProject.Database
{
    public class Context : DbContext
    {
        public DbSet<Account> accounts { get; set; }
        public DbSet<Post> posts { get; set; }
        public DbSet<Thread> threads { get; set; }
        public DbSet<Board> boards { get; set; }
    }
}