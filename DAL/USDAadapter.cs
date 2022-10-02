using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class USDAadapter
    {
        //https://api.nal.usda.gov/fdc/v1/foods/search?query={data.Title}&pageSize=2&api_key=iuHCuFBxp4hhEOZyWA4RYLPvXjrOfqfd8q6J9yLo
        //iuHCuFBxp4hhEOZyWA4RYLPvXjrOfqfd8q6J9yLo
        public string GetUSDA(string data)
        {

            string Url = $"https://api.nal.usda.gov/fdc/v1/foods/search?query={data}&pageSize=2&api_key=iuHCuFBxp4hhEOZyWA4RYLPvXjrOfqfd8q6J9yLo";

            var client = new RestClient(Url);

            var request = new RestRequest(new Uri(Url), Method.Get);

            RestResponse response = client.Execute(request);

            return response.Content;
        }
    }
}
