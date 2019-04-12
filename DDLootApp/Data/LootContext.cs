using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DDLootApp.Models
{
    public class LootContext : DbContext
    {
        public LootContext (DbContextOptions<LootContext> options)
            : base(options)
        {
        }

        public DbSet<MonsterItem> MonsterItems { get; set; }
        public DbSet<Monster> Monster { get; set; }

    }
}
