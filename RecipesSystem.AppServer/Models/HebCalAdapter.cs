//using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using RecipesSystem;
using RestSharp;

namespace RecipesSystem.AppServer.Models
{
    public class HebCalAdapter
    {
        public int Check()
        {
            //conect to gateway server
            string Url = $"http://localhost:5149/api/HebCal";

            var client = new RestClient(Url);

            var request = new RestRequest(new Uri(Url), Method.Get);

            RestResponse response = client.Execute(request);

            string holiday= response.Content;
            if (holiday.Contains("סוכות"))
                return 1;
            else if (holiday.Contains("חנוכה"))
                return 4;
            else if (holiday.Contains("פסח"))
                return 3;
            else if (holiday.Contains("שבועות"))
                return 2;
            else if (holiday.Contains("פורים"))
                return 5;
            else if (holiday.Contains("ראש השנה"))
                return 0;
            else
                return 6;
        }
    }
}
