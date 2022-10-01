namespace RecipesSystem.AppServer.Models
{
    public class WeatherAdapter
    {
        public string Check(string City)
        {
            //here we need to conect to the gateway server and get the weather values
            return $"in {City} today is cool and the temperature is 29 degrees";
        }
    }
}
