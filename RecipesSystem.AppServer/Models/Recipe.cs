using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Security.Policy;

namespace RecipesSystem.AppServer.Models
{
    public enum Tags {SOUP, SALAD, DESERT, CAKE,COOKIES, BREADS, FISH, CHICKEN, MEAT, QUICHE, PASTA,PIZZA}
    public enum Holidays { ROSH_HASHANA,SUKOT,SHAVUOT,PESACH,CHANUKA,PURIM,NOTHOLIDAY}
    public enum Weathers { COLD, HOT, NICE}
    public class Recipe
    {
        //need to add more error maegag
        public int Id { get; set; }
        [Required]
        [StringLength(50,ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [DisplayName("Description of the recipe")]
        public string Description { get; set; } = "";

        [DisplayName("Preparation instructions")]
        public string PrepInstructions { get; set; } = "";

        [DisplayName("Ingredients")]
        public string Ingredients  { get; set; }//Ingredients

        [DisplayName("Image URL")]
        public string ImageURL { get; set; }

        [DisplayName("preparation time")]
        [StringLength(10, ErrorMessage = "Making time cannot be longer than 10 characters.")]
        public string TimeToMake { get; set; }//Time To Make

        [DisplayName(" Cooking Time")]
        [StringLength(10, ErrorMessage = "Cooking time cannot be longer than 10 characters.")]
        public string  CookingTime { get; set; }

        [DisplayName("Diners size")]
        public int Diners { get; set; }//כמה סועדים neet to add an error if its a minus 

        [DisplayName("Tags")]
        public Tags Tag { get; set; }

        [DisplayName("Write Note")]
        public string Note { get; set; } = "";//note about the recipe

        public string Rate { get; set; } ="";//rate of the recipe

        public Holidays Holiday { get; set; } = Holidays.NOTHOLIDAY;//the date of the rating

        public Weathers Weather { get; set; } = Weathers.NICE;//the weather in the rating

    }
  

   
}
