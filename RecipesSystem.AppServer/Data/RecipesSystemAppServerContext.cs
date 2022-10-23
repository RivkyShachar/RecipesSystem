using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipesSystem.AppServer.Models;

namespace RecipesSystem.AppServer.Data
{
    public class RecipesSystemAppServerContext : DbContext
    {
        public DbSet<Recipe> Recipe { get; set; }
        public RecipesSystemAppServerContext(DbContextOptions<RecipesSystemAppServerContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .ToTable("Recipe");
            
            modelBuilder.Entity<Recipe>().Property(c => c.Description).HasConversion<string>();
            modelBuilder.Entity<Recipe>().Property(c => c.CookingTime).HasConversion<string>();
            modelBuilder.Entity<Recipe>().Property(c => c.Tag).HasConversion<string>();


            modelBuilder.Entity<Recipe>()
                .Property(c => c.Tag)
                .HasConversion<string>();
            modelBuilder.Entity<Nutriant>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Value).IsRequired();
                entity.Property(e => e.UnitOfMesurment).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
