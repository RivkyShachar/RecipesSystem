using Newtonsoft.Json;
using DP;
using static DP.ImaggaModel;
using System;
using System.Collections.Generic;
using System.Text;
using Root = DP.ImaggaModel.Root;
using static DP.USDAmodel;

namespace BL
{
    public class ImaggaLogic
    {
        public string IsGoodPic(ImaggaParamsDTO data)
        {
            string dairyFood = "";
            string meatyFood = "";
            string notKosherFood = "";
            List<string> tags = new List<string>();
            DAL.ImaggaAdapter dal = new DAL.ImaggaAdapter();
            Root myPicture = null;
            if (data.ImageUrl == null)
                return "Error: wrong URL";
            string myJson = dal.GetImageInformation(data.ImageUrl);
            if (myJson != null)
                myPicture = JsonConvert.DeserializeObject<Root>(myJson);
            if (myPicture != null && myPicture.status.type == "success")
            {
                foreach (var tag in myPicture.result.tags)
                {
                    if (notKosherFood.Contains(tag.tag.en) && tag.confidence > 50)
                        return "Error: the food is not kosher";
                    if (tag.tag.en == "food" && tag.confidence > 85)
                        tags.Add("food");
                    if (data.Title.Contains(tag.tag.en) && tag.confidence > 80)
                        tags.Add("title");
                    if (dairyFood.Contains(tag.tag.en) && tag.confidence > 50 && !tags.Contains("dairy"))
                        tags.Add("dairy");
                    if (meatyFood.Contains(tag.tag.en) && tag.confidence > 50 && !tags.Contains("meaty"))
                        tags.Add("meaty");
                }
            }
            else 
                return "Error: somthing got wrong, can't read the image";
            if(!tags.Contains("food"))
                return "Error: the food in not eaten";
            if (!tags.Contains("title"))
                return "Error: no match title and picture";
            if (tags.Contains("dairy") && tags.Contains("meaty"))
                return "Error: the food is not kosher";
            return "good image";
        }
    }
}
/*
if one of the ingrident contain the word.. and this word ins tot in the list of..
milk 
butter
cheese

products with milk need to be in a list
yogurt
whey
casein
Lactoferrin
Lactoglobulin
Lactose
Lactulose
Lactyc Yeast
Nisin Preparation
Nougat
Paneer
Potassium Caseinate
Powdered Whey
Protein Hydrolysates
Quark
Recaldent
Reduced Mineral Whey
Rennet
Rennet Casein
Sherbet
Sodium Caseinate
Sour Cream
Sour Cream Solids
Sweet Dairy Whey
Vegetarian Cheese with Casein
Whey
Whey Hydrolysates
Whey Powder
Whey Protein
Whey Protein Concentrate
Whey Protein Hydrolysates
Whey Solids
Zinc Caseinate
Acid Whey
Ammonium Caseinate
Calcium Caseinate
Casein
Casein Hydrolysates
Caseinate
Chocolate
Curds
Curd Whey
Custard
Dairy Product Solids
Delactosed Whey
Demineralized Why
Galactose
Ghee
Hydrolyzed Casein
Hydrolyzed Whey
Imitation Sour Cream
Iron Caseinate
Kefir
Kourmiss
Lactalbumin
Lactalbumin phosphate
Lactate solids
Lactitol Monohyrdrate













this is a list of kosher and not kosher mit
need to seperate between kosher and not 
to write in a list these words like in the imagga
make a list of kosher mit to check it its mit and milk together 
and list of not kosher food to check if the image is kosher
need to add to this list also milk and eggs and such that are not kosher

American bison
Water buffalo
Cattle
Domestic yak
Dromedary
Llama

Birds:
Chicken
Domestic duck
Domestic goose
Domestic turkey
Domesticated quail
Domestic pigeon
Guineafowl
Ostrich
Emu
Peacocks

Fish: need to delete the kosher ones
Barramundi
Catfish
Dentex
Flounder
Gilthead seabream
Halibut
Meagre
Milkfish
Rabbitfish
Seabass
Sharpsnout seabream
Striped bass
Sturgeon
Turbot
Wuchang bream

kosher:
Elk
Fallow deer
Moose (rarely tamed)
Red deer
Reindeer
White-tailed deer
Domestic sheep
Caprae (goats)
Domestic goat


not kosher:
Cricket
Grasshopper
Maguey worm
Mopane worm
Silkworm
Crayfish
Crab
Lobster
Shrimp
Prawns
Oysters
Mussels
Land snails
Abalone
Alligator
Crocodile
Turtles
Snakes
Bats
Domestic cat
Donkey
Horse
Rabbit
Kangaroo
Monkeys
Guinea pig
Rat
Suidae (pigs):
Domestic pig
Wild boar
Frogs
Cetaceans
Whales
Dog
 */