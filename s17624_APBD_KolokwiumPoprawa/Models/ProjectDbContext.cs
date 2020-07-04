using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace s17624_APBD_KolokwiumPoprawa.Models
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Firefighter> Firefighters { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<FireTruck> FireTrucks { get; set; }
        public DbSet<FirefighterAction> FirefighterActions { get; set; }
        public DbSet<FireTruckAction> FireTruckActions { get; set; }

        public ProjectDbContext()
        {

        }

        public ProjectDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FirefighterAction>().HasKey((e => new {e.IdAction, e.IdFirefighter}));
        }
    }
}
