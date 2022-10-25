using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    //returns the current weather in that city
    public class WeatherAdapter
    {
        public string GetWeather(string city)
        {
            string Url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid=98891b16fcfb1cb69c879bf2fb91c12a&units=metric";

            var client = new RestClient(Url);

            var request = new RestRequest(new Uri(Url), Method.Get);

            RestResponse response = client.Execute(request);

            return response.Content;
        }
    }
}
