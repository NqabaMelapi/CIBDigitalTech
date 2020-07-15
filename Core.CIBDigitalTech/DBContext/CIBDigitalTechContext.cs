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
        public DbSet<UserTestData> UserTestData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=52.136.122.242;database=db_CibDigitalTech;user=root;password=Hlehle2863501");
            
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

            modelBuilder.Entity<UserTestData>(entity =>
            {
                entity.Property(e => e.FirstName);
                entity.Property(e => e.LastName);
                entity.Property(e => e.UserName);
                entity.Property(e => e.Password);
                entity.Property(e => e.Customer);
                entity.Property(e => e.Role);
                entity.Property(e => e.Email);
                entity.Property(e => e.CellPhone);
                entity.HasNoKey();
            });
        }
    }
}
