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
                new Recipe{Name="cake",Description="write description1",
                    PrepInstructions="instructions",
                    Ingredients="the ingridents",
                    TimeToMake="x min",ImageURL="https://realfood.tesco.com/media/images/1400x919-MargaritaPizza-555a4065-2573-4b41-bcf3-7193cd095d8f-0-1400x919.jpg",
                    CookingTime="z min",Diners=2,Tag=Tags.DRINKS,Nutriants=new List<Nutriant>(),Holiday=Holidays.PESACH,Weather=Weathers.COLD},
                new Recipe{Name="cake",Description="write description2",
                    PrepInstructions="instructions",
                    Ingredients="the ingridents",
                    TimeToMake="x min",ImageURL="https://realfood.tesco.com/media/images/1400x919-MargaritaPizza-555a4065-2573-4b41-bcf3-7193cd095d8f-0-1400x919.jpg",
                    CookingTime="z min",Diners=2,Tag=Tags.DRINKS,Nutriants=null,Holiday=Holidays.PESACH,Weather=Weathers.COLD},
                new Recipe{Name="cake",Description="write description3",
                    PrepInstructions="instructions",
                    Ingredients="the ingridents",
                    TimeToMake="x min",ImageURL="https://realfood.tesco.com/media/images/1400x919-MargaritaPizza-555a4065-2573-4b41-bcf3-7193cd095d8f-0-1400x919.jpg",
                    CookingTime="z min",Diners=2,Tag=Tags.DRINKS,Nutriants=null,Holiday=Holidays.PESACH,Weather=Weathers.COLD},
                new Recipe{Name="cake",Description="write description4",
                    PrepInstructions="instructions",
                    Ingredients="the ingridents",
                    TimeToMake="x min",ImageURL="https://realfood.tesco.com/media/images/1400x919-MargaritaPizza-555a4065-2573-4b41-bcf3-7193cd095d8f-0-1400x919.jpg",
                    CookingTime="z min",Diners=2,Tag=Tags.DRINKS,Nutriants=null,Holiday=Holidays.PESACH,Weather=Weathers.COLD},
                new Recipe{Name="cake",Description="write description5",
                    PrepInstructions="instructions",
                    Ingredients="the ingridents",
                    TimeToMake="x min",ImageURL="https://realfood.tesco.com/media/images/1400x919-MargaritaPizza-555a4065-2573-4b41-bcf3-7193cd095d8f-0-1400x919.jpg",
                    CookingTime="z min",Diners=2,Tag=Tags.DRINKS,Nutriants=null,Holiday=Holidays.PESACH,Weather=Weathers.COLD},
                new Recipe{Name="cake",Description="write description6",
                    PrepInstructions="instructions",
                    Ingredients="the ingridents",
                    TimeToMake="x min",ImageURL="https://realfood.tesco.com/media/images/1400x919-MargaritaPizza-555a4065-2573-4b41-bcf3-7193cd095d8f-0-1400x919.jpg",
                    CookingTime="z min",Diners=2,Tag=Tags.DRINKS,Nutriants=null,Holiday=Holidays.PESACH,Weather=Weathers.COLD},

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


