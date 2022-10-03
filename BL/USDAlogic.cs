using static DP.USDAmodel;
using DP;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static DP.USDAparamsDTO;
using Root = DP.USDAmodel.Root;
using System.Linq;

namespace BL
{
    public class USDAlogic
    {
        //need to write the ecact way how it written example link https://api.nal.usda.gov/fdc/v1/foods/search?query=15-minute%20cherry%20tomato%20pasta&pageSize=2&api_key=iuHCuFBxp4hhEOZyWA4RYLPvXjrOfqfd8q6J9yLo
        string theNutrients = "Protein, Total lipid (fat), Carbohydrate, by difference, Energy, Sugars, total including NLEA, Sodium, Na, Fiber, Cholesterol, Fatty acids, Potassium, Calcium, Iron, Vitamin A, Vitamin C, total ascorbic acid";
        //string theNutrients = "Protein, Total lipid, Carbohydrate, Energy, Sugars, Sodium";
        public List<string> GetNutrientsValues(RecipeTitle recipeTitle)
        {
            List<string> nutrients=new List<string>();
            List<string> nutrientsNames = new List<string>();
            DAL.USDAadapter dal = new DAL.USDAadapter();
            Root myUSDA = null;
            string myJson = dal.GetUSDA(recipeTitle.Title);
            if (myJson != null)
                myUSDA = JsonConvert.DeserializeObject<Root>(myJson);
            foreach(var i in myUSDA.foods)
                if (recipeTitle.KeyWord == "x" || i.lowercaseDescription.Contains(recipeTitle.KeyWord))
                    foreach(var j in i.foodNutrients)
                        if (theNutrients.Contains(j.nutrientName) && !nutrientsNames.Contains(j.nutrientName))
                        {
                            nutrients.Add($"{j.nutrientName} {j.value}{j.unitName}");
                            nutrientsNames.Add(j.nutrientName);
                        }
            return nutrients;

        }
    }
}
/*{"nutrientId":1093,"nutrientName":"Sodium, Na","nutrientNumber":"307","unitName":"MG","derivationCode":"LCCD","derivationDescription":"Calculated from a daily value percentage per serving size measure","derivationId":75,"value":0.0,"foodNutrientSourceId":9,"foodNutrientSourceCode":"12","foodNutrientSourceDescription":"Manufacturer's analytical; partial documentation","rank":5800,"indentLevel":1,"foodNutrientId":3145992,"percentDailyValue":0}
 * {"nutrientId":1003,"nutrientName":"Protein","nutrientNumber":"203","unitName":"G","derivationCode":"LCCS","derivationDescription":"Calculated from value per serving size measure","derivationId":70,"value":0.0,"foodNutrientSourceId":9,"foodNutrientSourceCode":"12","foodNutrientSourceDescription":"Manufacturer's analytical; partial documentation","rank":600,"indentLevel":1,"foodNutrientId":4587770,"percentDailyValue":0}
 * {"nutrientId":1005,"nutrientName":"Carbohydrate, by difference","nutrientNumber":"205","unitName":"G","derivationCode":"LCCS","derivationDescription":"Calculated from value per serving size measure","derivationId":70,"value":14.3,"foodNutrientSourceId":9,"foodNutrientSourceCode":"12","foodNutrientSourceDescription":"Manufacturer's analytical; partial documentation","rank":1110,"indentLevel":2,"foodNutrientId":4587771,"percentDailyValue":7}
 * {"nutrientId":1008,"nutrientName":"Energy","nutrientNumber":"208","unitName":"KCAL","derivationCode":"LCCS","derivationDescription":"Calculated from value per serving size measure","derivationId":70,"value":52.0,"foodNutrientSourceId":9,"foodNutrientSourceCode":"12","foodNutrientSourceDescription":"Manufacturer's analytical; partial documentation","rank":300,"indentLevel":1,"foodNutrientId":4587772,"percentDailyValue":0}
 * {"nutrientId":2000,"nutrientName":"Sugars, total including NLEA","nutrientNumber":"269","unitName":"G","derivationCode":"LCCS","derivationDescription":"Calculated from value per serving size measure","derivationId":70,"value":10.4,"foodNutrientSourceId":9,"foodNutrientSourceCode":"12","foodNutrientSourceDescription":"Manufacturer's analytical; partial documentation","rank":1510,"indentLevel":3,"foodNutrientId":4587773,"percentDailyValue":0}
 * {"nutrientId":1004,"nutrientName":"Total lipid (fat)","nutrientNumber":"204","unitName":"G","derivationCode":"LCSL","derivationDescription":"Calculated from a less than value per serving size measure","derivationId":73,"value":0.65,"foodNutrientSourceId":9,"foodNutrientSourceCode":"12","foodNutrientSourceDescription":"Manufacturer's analytical; partial documentation","rank":800,"indentLevel":1,"foodNutrientId":6376585,"percentDailyValue":0}
 * {"nutrientId":1093,"nutrientName":"Sodium, Na","nutrientNumber":"307","unitName":"MG","derivationCode":"LCCS","derivationDescription":"Calculated from value per serving size measure","derivationId":70,"value":15.0,"foodNutrientSourceId":9,"foodNutrientSourceCode":"12","foodNutrientSourceDescription":"Manufacturer's analytical; partial documentation","rank":5800,"indentLevel":1,"foodNutrientId":25213849,"percentDailyValue":1}
 * {"nutrientId":2000,"nutrientName":"Sugars, total including NLEA","nutrientNumber":"269","unitName":"G","derivationCode":"LCCS","derivationDescription":"Calculated from value per serving size measure","derivationId":70,"value":11.7,"foodNutrientSourceId":9,"foodNutrientSourceCode":"12","foodNutrientSourceDescription":"Manufacturer's analytical; partial documentation","rank":1510,"indentLevel":3,"foodNutrientId":25213848}
 * 
 */
