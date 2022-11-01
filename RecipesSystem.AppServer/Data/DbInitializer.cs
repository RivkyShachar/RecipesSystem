using RecipesSystem.AppServer.Controllers;
using RecipesSystem.AppServer.Models;
using static DP.ImaggaModel;
using static DP.USDAparamsDTO;
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
            //add the recipes to the database
            var recipes = new Recipe[]
            {

            };
            foreach (Recipe r in recipes)
            {
                context.Recipe.Add(r);
            }
            context.SaveChanges();


            //nutriants for the recipes
            USDAadapter Uadapter = new USDAadapter();
           
            foreach(Recipe r in recipes)
            {

                List<Nutrient> nutriants = Uadapter.Check(r.Name, r.Tag.ToString());
                r.Nutriants = new List<Nutriant>();               
                foreach (Nutrient nutr in nutriants)
                {
                    Nutriant nutrient = new Nutriant();
                    nutrient.Value = nutr.Value;
                    nutrient.Name = nutr.Name;
                    nutrient.UnitOfMesurment = nutr.UnitName;//לא בטוחה שזה המקביל שלו אבל נבדוק
                    r.Nutriants.Add(nutrient);
                }
            }
            context.SaveChanges();
        }
    }
}


