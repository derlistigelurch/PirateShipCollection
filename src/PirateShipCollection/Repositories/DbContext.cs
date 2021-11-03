using Microsoft.EntityFrameworkCore;
using PirateShipCollection.Models;

namespace PirateShipCollection.Repositories
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext()
        {
        }

        public DbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ship>().HasKey(s => s.DbId);
        }

        public virtual DbSet<Ship> Ships { get; set; }
    }
}