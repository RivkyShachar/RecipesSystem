using System.ComponentModel;

namespace RecipesSystem.AppServer.Models
{
    public class NewRecipe
    {
        public string Id { get; set; }

        [DisplayName("Description of the recipe")]
        public string Description { get; set; }

        [DisplayName("Preparation instructions")]
        public string PrepInstructions { get; set; }

        [DisplayName("Title key word")]
        public string KeyWord { get; set; }

        [DisplayName("Image URL")]
        public string ImageURL { get; set; }
        public string MakingTime { get; set; }
        public string CookingTime { get; set; }
        public List<RTag> RTags { get; set; }

        public List<Nutriant> Nutriants { get; set; }
    }
}
