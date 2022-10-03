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

            return response.Content;
            //returns json of list of holidays
        }
    }
}
