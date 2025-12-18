using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public static class OpenWeatherMapAPI
    {
        public static void WeatherReport()
        {
            var appsettingsText = File.ReadAllText("appsettings.json");

            var client = new HttpClient();
            
            var apiKey = JObject.Parse(appsettingsText).GetValue("apikey").ToString();
            
            Console.WriteLine("Pleas enter your chosen Zip Code for a city:");
            
            var zip = Console.ReadLine();
            
            var weatherUrl = 
                $"https://api.openweathermap.org/data/2.5/weather?zip={zip},&appid={apiKey}&units=imperial";
            
            var weatherResponseJson = client.GetStringAsync(weatherUrl).Result;
            
            var weatherObject= JObject.Parse(weatherResponseJson); //Had to consult video for this
            
            Console.WriteLine($" ZipCode: {zip}\n " +
                              $"City Name: {weatherObject["name"]}\n " +
                              $"Temperature: {weatherObject["main"]["temp"]} °F\n " +
                              $"Feels Like: {weatherObject["main"]["feels_like"]}\n " +
                              $"Humidity: {weatherObject["main"]["humidity"]}\n " +
                              $"Weather Type: {weatherObject["weather"][0]["description"]}");
        }
    }
}
