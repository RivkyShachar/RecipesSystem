using static DP.WeatherModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class WeatherLogic
    {
        public string GetWeather(string City)
        {
            DAL.WeatherAdapter dal = new DAL.WeatherAdapter();
            Root myWeather = null;
            string myJson = dal.GetWeather(City);
            if (myJson != null)
            {
                myWeather = JsonConvert.DeserializeObject<Root>(myJson);
            }
            double currentWeather = myWeather.main.feels_like;
            if (currentWeather <= 17)
            {
                return "Cold";
            }
            else if (currentWeather <= 27)
            {
                return "Nice";
            }
            else
            {
                return "Hot";
            }

        }
    }
}
