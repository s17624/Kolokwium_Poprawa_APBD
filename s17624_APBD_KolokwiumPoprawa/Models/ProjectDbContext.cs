using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace s17624_APBD_KolokwiumPoprawa.Models
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext()
        {

        }

        public ProjectDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
