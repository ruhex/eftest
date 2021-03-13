using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test1.Models;

namespace Test1.Brokers
{
    public class StorageBroker : DbContext
    {
        public StorageBroker(DbContextOptions<StorageBroker> options)
            : base(options)
        {
            //this.Database.Migrate();
            // Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}
