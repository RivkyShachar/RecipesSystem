using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    internal class ImaggaAdapter
    {
        public string GetImageInformation(string ImageUrl)
        {
            string apiKey = "acc_4858251230dcb88";
            string apiSecret = "c2f19534f3e9c73697368ef9cfe0cae1";
            // string imageUrl = "https://docs.imagga.com/static/images/docs/sample/japan-605234_1280.jpg";

            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));
            var client = new RestClient("https://api.imagga.com/v2/tags");

            var request = new RestRequest(new Uri("https://api.imagga.com/v2/tags"), Method.Get);
            request.AddParameter("image_url", ImageUrl);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

            RestResponse response = client.Execute(request);

            return response.Content;

        }
    }
}
