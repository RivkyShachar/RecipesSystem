using RestSharp;

namespace RecipesSystem.AppServer.Models
{
    public class USDAadapter
    {
        public string Check(string Title,string KeyWord)
        {        //this class will ask the gateway server for nutriants values about food
                 //conect to gateway server
            string Url = $"http://localhost:5149/api/USDA?title={Title}&keyWord={KeyWord}";

            var client = new RestClient(Url);

            var request = new RestRequest(new Uri(Url), Method.Get);

            RestResponse response = client.Execute(request);

            return response.Content;
        }

    }
}
