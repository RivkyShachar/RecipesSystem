﻿using RestSharp;

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

            return response.Content;
        }
    }
}
