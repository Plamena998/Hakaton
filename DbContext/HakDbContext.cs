using Infrastructure.Enums;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBContext
{
    public class HakDbContext : DbContext
    {
        public HakDbContext()
        {
        }

        public HakDbContext(DbContextOptions<HakDbContext> options) : base(options)
        {
        }

        public DbSet<Mentor> mentors { get; set; }
        public DbSet<Procedure> procedures { get; set; }
        public DbSet<Science> sciences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Constant.ConnetionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Defaults for audit fields and identity
            modelBuilder.Entity<Mentor>(e =>
            {
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                e.Property(p => p.IsDeleted).HasDefaultValue(false);
            });

            modelBuilder.Entity<Science>(e =>
            {
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                e.Property(p => p.IsDeleted).HasDefaultValue(false);
            });

            modelBuilder.Entity<Procedure>(e =>
            {
                e.Property(p => p.Id).ValueGeneratedOnAdd();
                e.Property(p => p.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
                e.Property(p => p.IsDeleted).HasDefaultValue(false);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
