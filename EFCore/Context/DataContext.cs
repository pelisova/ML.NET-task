using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PVSystem>? Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // override method
            modelBuilder.Entity<PVSystem>().HasKey(k => k.Id);
            modelBuilder.Entity<PVSystem>().HasIndex(p => p.PvSystemId).IsUnique();
        }

    }
}