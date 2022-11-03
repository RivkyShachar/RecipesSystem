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
        [Required(ErrorMessage = "Required field")]
        [StringLength(50,ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }

        [DisplayName("Description of the recipe")]
        public string Description { get; set; } = "";

        [DisplayName("Preparation instructions")]
        [Required(ErrorMessage = "Required field")]
        [MinLength(10, ErrorMessage ="Instructions cannot be shorter than 10 characters.")]
        public string PrepInstructions { get; set; }

        [DisplayName("Ingredients")]
        [Required(ErrorMessage = "Required field")]
        [MinLength(10, ErrorMessage = "Ingredients cannot be shorter than 10 characters.")]
        public string Ingredients  { get; set; }

        [DisplayName("Image URL")]
        [Required(ErrorMessage = "Required field")]
        public string ImageURL { get; set; }

        [DisplayName("preparation time")]
        [Required(ErrorMessage = "Required field")]
        [StringLength(10, ErrorMessage = "Making time cannot be longer than 10 characters.")]
        public string TimeToMake { get; set; }

        [DisplayName(" Cooking Time")]
        [Required(ErrorMessage = "Required field")]
        [StringLength(10, ErrorMessage = "Cooking time cannot be longer than 10 characters.")]
        public string  CookingTime { get; set; }

        [DisplayName("Diners size")]
        [Required(ErrorMessage = "Required field")]
        [Range(1, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Diners { get; set; }

        [DisplayName("Tags")]
        [Required(ErrorMessage = "Required field")]
        public Tags Tag { get; set; }

        [DisplayName("Write Note")]
        public string Note { get; set; } = "";//note about the recipe

        public string Rate { get; set; } ="";//rate of the recipe

        [Required(ErrorMessage = "Required field")]
        public Holidays Holiday { get; set; } = Holidays.NOTHOLIDAY;//the date of the rating

        [Required(ErrorMessage = "Required field")]
        public Weathers Weather { get; set; } = Weathers.NICE;//the weather in the rating

    }
  

   
}
