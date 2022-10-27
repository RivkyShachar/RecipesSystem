using RestSharp;

namespace RecipesSystem.AppServer.Models
{
    public class WeatherAdapter
    {
        public string Check(string City)
        {
            //conect to gateway server
            string Url = $"http://localhost:5149/api/Weather?city={City}";

            var client = new RestClient(Url);

            var request = new RestRequest(new Uri(Url), Method.Get);

            RestResponse response = client.Execute(request);

            string temperature= response.Content;

            if (temperature.Contains("Hot"))
                return "Recipes for hot days";
            else if (temperature.Contains("Cold"))
                return "Recipes for cold days";
            return "Nice weather";

        }
    }
}
