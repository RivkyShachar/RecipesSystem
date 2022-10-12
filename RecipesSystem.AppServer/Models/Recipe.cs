using System.ComponentModel;
using static RecipesSystem.AppServer.Models.Enum;

namespace RecipesSystem.AppServer.Models
{

    public class Recipe
    {
        public string Id { get; set; }

        [DisplayName("Description of the recipe")]
        public string Description { get; set; }

        [DisplayName("Preparation instructions")]
        public string PrepInstructions { get; set; }

        [DisplayName("Tools")]
        public string Tools { get; set; }  //כלים להכנת המתכון מה צריך  

        [DisplayName("Ingredients")]
        public string Ingredients  { get; set; }//מרכיבים 

        [DisplayName("Image URL")]
        public string ImageURL { get; set; }

        [DisplayName("preparation time")]
        public string TimeToMake { get; set; }//זמן הכנה

        [DisplayName(" Cooking Time")]
        public string  cookingTime { get; set; }//זמן בישול

        [DisplayName("Diners size")]
        public int Diners { get; set; }//כמה סועדים 

        [DisplayName("Tags")]
        public Tags Tag { get; set; }

        [DisplayName("Nutriant")]
        public List<Nutriant> Nutriants { get; set; }



    }
  
    public class RTag
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Nutriant
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        public string UnitOfMesurment { get; set; }
    }
}
