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
            //get the weather in city
            DAL.WeatherAdapter dal = new DAL.WeatherAdapter();
            Root myWeather = null;
            string myJson = dal.GetWeather(City);
            if (myJson != null)
                myWeather = JsonConvert.DeserializeObject<Root>(myJson);

            //return if Cold/Hot/Nice according to the weather
            double currentWeather = myWeather.main.feels_like;
            if (currentWeather <= 22)
                return "Cold";
            else if (currentWeather <= 26)     
                return "Nice";
            else return "Hot";
        }
    }
}
