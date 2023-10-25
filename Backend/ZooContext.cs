using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Zoo.Entities;

namespace Zoo.Backend
{
    public class ZooContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Caretaker> Caretakers { get; set; }

        public ZooContext() : base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=.\\DbZoo");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(eb =>
            {
                eb.HasKey(a => a.Id);
                eb.Property(a => a.Name).HasColumnType("varchar(50)");
                eb.Property(a => a.Species).IsRequired();
                eb.HasOne(a => a.Caretaker)
                .WithMany(ct => ct.Animals)
                .HasForeignKey(a => a.CaretakerId);
            });
            modelBuilder.Entity<Caretaker>(eb =>
            {
                eb.HasKey(ct => ct.Id);
                eb.Property(ct => ct.FirstName).HasColumnType("varchar(50)");
                eb.Property(ct => ct.LastName).HasColumnType("varchar(50)");
            });
        }
    }
}
