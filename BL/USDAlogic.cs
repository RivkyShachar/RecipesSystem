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
    /*Protein
     * Calcium
     * Iron
     * Vitamin A
     * Vitamin C
     * Protein
     * Total lipid
     * Carbohydrate
     * Energy
     * Sugars
     * Fiber
     * Potassium
     * Sodium
     * Cholesterol
     * Fatty acids
     * Fatty acids
     * Protein
     * Total lipid
     * Carbohydrate
     * Carbohydrate
     * Energy
     * Sugars
     * Fiber
     * Calcium
     * Iron
     * Sodium
     * 
     * 
     * Protein
     * Total lipid
     * Carbohydrate
     * Energy
     * Sugars
     * Sodium
     */
    public class USDAlogic
    {
        public Nutrient[] GetNutrientsValues(string data)
        {
            Nutrient[] nutrients=new Nutrient[6];
            DAL.USDAadapter dal = new DAL.USDAadapter();
            Root myUSDA = null;
            string myJson = dal.GetUSDA(data);
            if (myJson != null)
            {
                myUSDA = JsonConvert.DeserializeObject<Root>(myJson);
            }
            int idx = 0;
            foreach(var i in myUSDA.foods[0].foodNutrients)
            {
                if (i.nutrientName == "Sodium" || i.nutrientName == "Sugars" || i.nutrientName == "Energy" || i.nutrientName == "Carbohydrate" || i.nutrientName == "Protein" || i.nutrientName == "Total lipid")
                {
                    //if the nutrient is not in the list already so
                    nutrients[idx] = new Nutrient { Name = i.nutrientName, UnitName = i.unitName, Value = i.value };
                    idx++;
                }
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
