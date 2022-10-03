using Newtonsoft.Json;
using DP;
using static DP.ImaggaModel;
using System;
using System.Collections.Generic;
using System.Text;
using Root = DP.ImaggaModel.Root;

namespace BL
{
    public class ImaggaLogic
    {
        public bool IsGoodPic(ImaggaParamsDTO data)
        {
            string result = "false";
            DAL.ImaggaAdapter dal = new DAL.ImaggaAdapter();
            Root myPicture = null;
            if (data.ImageUrl == null)
                return false;
            string myJson = dal.GetImageInformation(data.ImageUrl);
            if (myJson != null)
            {
                myPicture = JsonConvert.DeserializeObject<Root>(myJson);
            }
            if (myPicture != null && myPicture.status.type == "success")
                foreach (var tag in myPicture.result.tags)
                    if (tag.tag.en == "food" && tag.confidence > 85)
                    {
                        result = "food";
                        break;
                    }
            if(result=="food")
                foreach (var tag in myPicture.result.tags)
                    if (data.Title.Contains(tag.tag.en) && tag.confidence > 80)
                    {
                        result = "title";
                        break;
                    }
            //need to check if it's kosher
            if (result == "title")
                return true;
            return false;



            
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