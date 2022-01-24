using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeForCoffee.Models;

namespace TimeForCoffee.Data
{
    public class TimeForCoffeeContext:DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Cafe> Cafes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Barista> Baristas { get; set; }
        public DbSet<CafeBarista> CafeBaristas { get; set; }

        public TimeForCoffeeContext(DbContextOptions<TimeForCoffeeContext> options):base(options)
        {

        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //one-to-one
            modelBuilder.Entity<Cafe>()
                .HasOne(c => c.Location)
                .WithOne(l => l.Cafe)
                .HasForeignKey<Cafe>(c => c.LocationId);

            
            //one-to-many
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User);

            modelBuilder.Entity<Cafe>()
                .HasMany(c => c.Reviews)
                .WithOne(r => r.Cafe);


            //many-to-many
            modelBuilder.Entity<CafeBarista>()
                .HasKey(cb => new { cb.BaristaId, cb.CafeId });
            modelBuilder.Entity<CafeBarista>()
                .HasOne(cb => cb.Barista)
                .WithMany(cb => cb.Cafes)
                .HasForeignKey(cb => cb.BaristaId);
            modelBuilder.Entity<CafeBarista>()
                .HasOne(cb => cb.Cafe)
                .WithMany(cb => cb.Baristas)
                .HasForeignKey(cb => cb.CafeId);



            base.OnModelCreating(modelBuilder);
        }
    }
}
