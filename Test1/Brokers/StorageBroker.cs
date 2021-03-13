using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
    }
}
