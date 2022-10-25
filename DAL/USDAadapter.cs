using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class USDAadapter
    {
        //return the nutrients of a given recipe
        public string GetUSDA(string recipeTitle)
        {

            string Url = $"https://api.nal.usda.gov/fdc/v1/foods/search?query={recipeTitle}&pageSize=2&api_key=iuHCuFBxp4hhEOZyWA4RYLPvXjrOfqfd8q6J9yLo";

            var client = new RestClient(Url);

            var request = new RestRequest(new Uri(Url), Method.Get);

            RestResponse response = client.Execute(request);

            return response.Content;
        }
    }
}
