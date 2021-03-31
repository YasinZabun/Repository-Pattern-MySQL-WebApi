using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Contexts
{
   public class MasterContext:DbContext
    {
        public DbSet<Costumer> Costumers { get; set; }
        public DbSet<Product> Products { get; set; }

        public MasterContext(DbContextOptions<MasterContext> options) : base(options)
        {

        }

        public MasterContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Costumer>().ToTable("Costumers");
            modelBuilder.Entity<Product>().ToTable("Products");

            modelBuilder.Entity<Costumer>().HasKey(ug => ug.Id).HasName("PK_Costumers");
            modelBuilder.Entity<Product>().HasKey(u => u.Id).HasName("PK_Products");

            /* modelBuilder.Entity<UserGroup>().HasIndex(p => p.Name).IsUnique().HasDatabaseName("Idx_Name");
             modelBuilder.Entity<User>().HasIndex(u => u.FirstName).HasDatabaseName("Idx_FirstName");
             modelBuilder.Entity<User>().HasIndex(u => u.LastName).HasDatabaseName("Idx_LastName");*/


            modelBuilder.Entity<Costumer>().Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            //modelBuilder.Entity<Costumer>().HasKey(c => c.Id)
            modelBuilder.Entity<Costumer>().Property(c => c.FirstName).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Costumer>().Property(c => c.LastName).HasColumnType("nvarchar(100)").IsRequired();
            modelBuilder.Entity<Costumer>().Property(c => c.MailAdress).HasColumnType("nvarchar(45)").IsRequired();

            modelBuilder.Entity<Product>().Property(p => p.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.Name).HasColumnType("nvarchar(50)").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.OwnerId).HasColumnType("int").IsRequired();
            modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasColumnType("int").IsRequired();
            
            modelBuilder.Entity<Product>().HasOne<Costumer>().WithMany().HasPrincipalKey(c => c.Id).HasForeignKey(p => p.OwnerId).OnDelete(DeleteBehavior.NoAction).HasConstraintName("OwnerId");

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseMySQL(Environment.GetEnvironmentVariable("MYSQL"));
        }
    }
}
