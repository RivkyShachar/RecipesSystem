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
        [DisplayName("Image URL")]
        public string ImageURL { get; set; }
        public List<RTag> RTags { get; set; }

        public List<Nutriant> Nutriants { get; set; }

    }
}
