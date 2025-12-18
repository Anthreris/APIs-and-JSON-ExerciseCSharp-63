using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class RonVSKanyeAPI
    {
        private static string GetKanyeQuote(HttpClient client)
        {
            var kanyeResponseJson = client.GetStringAsync("https://api.kanye.rest/").Result;
            
            var kanyeQuote = JObject.Parse(kanyeResponseJson).GetValue("quote").ToString();
            
            return kanyeQuote;
        }

        private static string GetRonQuote(HttpClient client)
        {
            var ronResponseJson = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;

            var ronQuote = ronResponseJson.Replace('[', ' ').Replace(']', ' ').Replace('"', ' ').Trim();
                // "Similar to the original attempt in Lecture Demo before changing to be in line with exercise prompt and video":    JObject.Parse(ronResponseJson).GetValue("quote").ToString();
            
            return ronQuote;
        }
        
        public static void Discussion()
        {
            var client = new HttpClient();
            
            for (int i = 1; i <= 5; i++)
            {
               //Had ... on one Console.WriteLine()But saw how the video did it to add time for the user to read. Thus implemented similar functions.
                Console.WriteLine($"Kanye: {GetKanyeQuote(client)}");
                Console.Write(".");
                Thread.Sleep(500);
                Console.Write(".");
                Thread.Sleep(500);
                Console.WriteLine(".");
                Thread.Sleep(2300);
                Console.WriteLine($"Ron: {GetRonQuote(client)}");
                Console.Write(".");
                Thread.Sleep(500);
                Console.Write(".");
                Thread.Sleep(500);
                Console.WriteLine(".");
                Thread.Sleep(2300);
            }
        }
    }
}
