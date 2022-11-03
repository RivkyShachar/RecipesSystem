using RestSharp;

namespace RecipesSystem.AppServer.Models
{
    public class USDAadapter
    {
        public List<DP.USDAparamsDTO.Nutrient> Check(string Title,string Tag)
        { 
            GetwayServer.Controllers.USDAController controller = new GetwayServer.Controllers.USDAController();

            //send the title of the recipe to the server
            return controller.Get(Title,Tag);
        }

    }
}

