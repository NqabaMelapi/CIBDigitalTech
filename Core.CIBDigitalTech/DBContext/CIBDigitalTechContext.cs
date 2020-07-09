using System;
using Core.CIBDigitalTech.Model;
using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore;


namespace Core.CIBDigitalTech.DBContext
{
    public class CIBDigitalTechContext : DbContext
    {
        public CIBDigitalTechContext()
        {
        }

        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=52.136.122.242;database=CIBDigitalTech;user=user;password=password");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.ID);
                entity.Property(e => e.FirstName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.UserName);
                entity.Property(e => e.Password);
                entity.Property(e => e.Customer);
                entity.Property(e => e.Role);
                entity.Property(e => e.Email);
                entity.Property(e => e.CellPhone);

            });
        }
    }
}
