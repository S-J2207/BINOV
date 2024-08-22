using Microsoft.EntityFrameworkCore;
using MicroServiceCRUD.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServiceCRUD.Repositories
{
    public class DatabaseService : DbContext
    {
        public DatabaseService(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ADSO> ADSO { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            EntityConfuguration(modelBuilder);
        }

        private void EntityConfuguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADSO>().ToTable("ADSO");
            modelBuilder.Entity<ADSO>().HasKey(u => u.Id);
            modelBuilder.Entity<ADSO>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<ADSO>().Property(u => u.Name).HasColumnName("Nombre");
        }

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}
