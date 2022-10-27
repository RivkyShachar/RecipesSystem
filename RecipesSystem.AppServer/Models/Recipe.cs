using System.ComponentModel;
using System.Drawing;
using System.Security.Policy;

namespace RecipesSystem.AppServer.Models
{
    public enum Tags { BREADRECIPES, EVERYDAYCOOKING, LUNCHRECIPES, DINNERRECIPES, MAINDISHES, BREAKFASTANDBRUNCH, DRINKS, APPETIZERSANDSNACKS }
    public enum Holidays { ROSHHASHANA,SUKOT,SHAVUOT,PESACH,CHANUKA,NOTHOLIDAY}
    public enum Weathers { COLD, HOT, NICE}
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayName("Description of the recipe")]
        public string Description { get; set; }

        [DisplayName("Preparation instructions")]
        public string PrepInstructions { get; set; }

        [DisplayName("Ingredients")]
        public string Ingredients  { get; set; }//מרכיבים 

        [DisplayName("Image URL")]
        public string ImageURL { get; set; }

        [DisplayName("preparation time")]
        public string TimeToMake { get; set; }//זמן הכנה

        [DisplayName(" Cooking Time")]
        public string  CookingTime { get; set; }//זמן בישול

        [DisplayName("Diners size")]
        public int Diners { get; set; }//כמה סועדים 

        [DisplayName("Tags")]
        public Tags Tag { get; set; }

        [DisplayName("Nutriant")]
        public List<Nutriant> Nutriants { get; set; }

        [DisplayName("Write Note")]
        public string Note { get; set; } = "";//note about the recipe

        public string Rate { get; set; } ="";//rate of the recipe

        public Holidays Holiday { get; set; }//the date of the rating

        public Weathers Weather { get; set; }//the weather in the rating

    }
  

   
}
