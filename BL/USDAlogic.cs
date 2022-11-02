using static DP.USDAmodel;
using DP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static DP.USDAparamsDTO;
using Root = DP.USDAmodel.Root;
using System.Linq;
using System.Reflection;

namespace BL
{
    public class USDAlogic
    {
        //need to write the ecact way how it written example link https://api.nal.usda.gov/fdc/v1/foods/search?query=15-minute%20cherry%20tomato%20pasta&pageSize=2&api_key=iuHCuFBxp4hhEOZyWA4RYLPvXjrOfqfd8q6J9yLo
        string theNutrients = "Protein, Total lipid (fat), Carbohydrate, by difference, Energy, Sugars, total including NLEA, Sodium, Na, Fiber, Cholesterol, Fatty acids, Potassium, Calcium, Iron, Vitamin A, Vitamin C, total ascorbic acid";
        //string theNutrients = "Protein, Total lipid, Carbohydrate, Energy, Sugars, Sodium";


        //returns all the nutrients of the recipe
        public Nutrient[] GetNutrientsValues(RecipeTitle recipeTitle)
        {
            //sent the recipe title to get all the recipe
            Nutrient[] nutrients=new Nutrient[7];//שינוי
            int counter = 0;
            List<string> nutrientsNames = new List<string>();
            DAL.USDAadapter dal = new DAL.USDAadapter();
            Root myUSDA = null;
            string myJson = dal.GetUSDA(recipeTitle.Title);
            if (myJson != null)
                myUSDA = JsonConvert.DeserializeObject<Root>(myJson);
            
            //add all the relevant nutrients to the recipe
            foreach(var i in myUSDA.foods)
            { 
                if (i.lowercaseDescription.Contains(recipeTitle.Title.ToLower()) || i.lowercaseDescription.Contains(recipeTitle.Tag.ToLower()))
                {
                    foreach(var j in i.foodNutrients)
                    { 
                        if (theNutrients.Contains(j.nutrientName) && !nutrientsNames.Contains(j.nutrientName) &&counter!=7)
                        {
                            nutrients[counter]= new Nutrient { Name=j.nutrientName, UnitName= j.unitName, Value= j.value };
                            nutrientsNames.Add(j.nutrientName);
                            counter++;
                         }
                     }
                }
            }
            if(counter==7)
            {
                return nutrients;
            }
            return null;

        }
    }
}

