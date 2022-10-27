//using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using RecipesSystem;
using RestSharp;

namespace RecipesSystem.AppServer.Models
{
    public class HebCalAdapter
    {
        public string Check()
        {
            //conect to gateway server
            string Url = $"http://localhost:5149/api/HebCal";

            var client = new RestClient(Url);

            var request = new RestRequest(new Uri(Url), Method.Get);

            RestResponse response = client.Execute(request);

            string holiday= response.Content;
            if (holiday.Contains("סוכות"))
                return "recipes for sukot";
            else if (holiday.Contains("חנוכה"))
                return "Recipes for chanuka";
            else if (holiday.Contains("פסח"))
                return "Recipes for pesach";
            else if (holiday.Contains("שבועות"))
                return "Recipes for shavuot";
            else if (holiday.Contains("פורים"))
                return "Recipes for purim";
            else if (holiday.Contains("ראש השנה"))
                return "Recipes for rosh hashana";
            else
                return "No holiday";
        }
    }
}
