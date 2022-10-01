using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RecipesSystem.AppServer.Models;

namespace RecipesSystem.AppServer.Data
{
    public class RecipesSystemAppServerContext : DbContext
    {
        public RecipesSystemAppServerContext (DbContextOptions<RecipesSystemAppServerContext> options)
            : base(options)
        {
        }

        public DbSet<RecipesSystem.AppServer.Models.Recipe> Recipe { get; set; } = default!;
    }
}
