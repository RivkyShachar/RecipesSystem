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
            modelBuilder.Entity<Recipe>().ToTable("Recipe");
            modelBuilder.Entity<Recipe>().Property(c => c.Id).HasConversion<int>();
            modelBuilder.Entity<Recipe>().Property(c => c.Name).HasConversion<string>();
            modelBuilder.Entity<Recipe>().Property(c => c.Description).HasConversion<string>();
            modelBuilder.Entity<Recipe>().Property(c => c.PrepInstructions).HasConversion<string>();
            modelBuilder.Entity<Recipe>().Property(c => c.Ingredients).HasConversion<string>();
            modelBuilder.Entity<Recipe>().Property(c => c.ImageURL).HasConversion<string>();
            modelBuilder.Entity<Recipe>().Property(c => c.TimeToMake).HasConversion<string>();
            modelBuilder.Entity<Recipe>().Property(c => c.CookingTime).HasConversion<string>();
            modelBuilder.Entity<Recipe>().Property(c => c.Diners).HasConversion<int>();

            modelBuilder.Entity<Recipe>().Property(c => c.Tag).HasConversion<string>();
            modelBuilder.Entity<Recipe>().Property(c => c.Note).HasConversion<string>();
            modelBuilder.Entity<Recipe>().Property(c => c.Rate).HasConversion<string>();
            modelBuilder.Entity<Recipe>().Property(c => c.Holiday).HasConversion<string>();
            modelBuilder.Entity<Recipe>().Property(c => c.Weather).HasConversion<string>();
          

            base.OnModelCreating(modelBuilder);
        }



    }
}
