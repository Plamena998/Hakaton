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

        public DbSet<Mentor> mentors { get; set; }
        public DbSet<Procedure> procedures { get; set; }
        public DbSet<Science> sciences { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Constant.ConnetionString);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Procedure>()
            //    .HasOne(i => i.Science)
            //    .WithMany(o => o.)
            //    .HasForeignKey(i => i.IndustryId)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Organization>()
            //   .HasOne(c => c.Country)
            //   .WithMany(o => o.OrganizationList)
            //   .HasForeignKey(c => c.CountryId)
            //   .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Organization>()
            //   .HasOne(f => f.FoundedYear)
            //   .WithMany(o => o.OrganizationsList)
            //   .HasForeignKey(f => f.FoundedYearId)
            //   .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
