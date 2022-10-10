using System.ComponentModel;

namespace RecipesSystem.AppServer.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [DisplayName("Description of the recipe")]
        public string Description { get; set; }

        [DisplayName("Preparation instructions")]
        public string PrepInstructions { get; set; }

        public string Tools { get; set; }  //כלים להכנת המתכון מה צריך  

        public string Integredient { get; set; }//מרכיבים 

        //[DisplayName("Title key word")]
        // public string KeyWord { get; set; }

        [DisplayName("Image URL")]
        public string ImageURL { get; set; }

        public DateTimeKind TimeToMake { get; set; }//זמן הכנה

        public DateTimeKind cookingTime { get; set; }//זמן בישול

        public int Diners { get; set; }//כמה סועדים 

        public List<RTag> RTags { get; set; } 

        public List<Nutriant> Nutriants { get; set; }



    }
}
