using System.Diagnostics;
using RecipesSystem.AppServer.Models;
using System;
using System.Linq;

namespace RecipesSystem.AppServer.Data
{

    public static class DbInitializer
    {
        public static void Initialize(RecipesSystemAppServerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Recipe.Any())
            {
                return;   // DB has been seeded
            }

            var recipes = new Recipe[]
            {
                new Recipe{Description="a",PrepInstructions="b",ImageURL="c",Tag= 0},
                new Recipe{Description="f",PrepInstructions="b",ImageURL="cd",Tag=Models.Enum.Tags.APPETIZERSANDSNACKS },
                new Recipe{Description="af",PrepInstructions="b",ImageURL="sc",Tag=Models.Enum.Tags.APPETIZERSANDSNACKS },
                new Recipe{Description="ad",PrepInstructions="b",ImageURL="cf",Tag=Models.Enum.Tags.APPETIZERSANDSNACKS  },
                new Recipe{Description="ad",PrepInstructions="b",ImageURL="ct",Tag=Models.Enum.Tags.APPETIZERSANDSNACKS  },
            };
            foreach (Recipe r in recipes)
            {
                context.Recipe.Add(r);
            }
            context.SaveChanges();


        }
    }
}
