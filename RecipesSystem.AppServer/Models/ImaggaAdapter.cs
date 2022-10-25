using RestSharp;
using System.Reflection;

namespace RecipesSystem.AppServer.Models
{
    public class ImaggaAdapter
    {
        public string Check(string Title,string ImageURL,string Tag)
        {
            //this class will ask the gateway server for nutriants values about food
            //conect to gateway server
            string Url = $"http://localhost:5149/api/imagga?title={Title}&imageURL={ImageURL}&tag={Tag}";

            var client = new RestClient(Url);

            var request = new RestRequest(new Uri(Url), Method.Get);

            RestResponse response = client.Execute(request);

            return response.Content;
        }
    }
}
