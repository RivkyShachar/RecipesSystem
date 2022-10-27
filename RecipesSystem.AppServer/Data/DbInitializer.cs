using RecipesSystem.AppServer.Models;
using static DP.ImaggaModel;
using static DP.WeatherModel;

namespace RecipesSystem.AppServer.Data
{
    public class DbInitializer
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
                new Recipe{Name="recipe1",Description="write description",PrepInstructions="instructions",Ingredients="the ingridents",TimeToMake="x min",ImageURL="https://realfood.tesco.com/media/images/1400x919-MargaritaPizza-555a4065-2573-4b41-bcf3-7193cd095d8f-0-1400x919.jpg",CookingTime="z min",Diners=2,Tag=Tags.DRINKS,Nutriants=null,Holiday=Holidays.PESACH,Weather=Weathers.COLD}

            };
            foreach (Recipe r in recipes)
            {
                context.Recipe.Add(r);
            }
            context.SaveChanges();

           
        }
    }
}


