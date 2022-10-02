using DP;
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
            foreach (var item in myWeather.items)
            {
                var a = item;
            }
            return "";
        }
    }
}
