using System;
using System.Net.Http;

namespace weather_app_dotnet {

    class Program {
    static readonly HttpClient client = new HttpClient();
        static async System.Threading.Tasks.Task Main(string[] args){
            Console.WriteLine("Hello World!");
            var url = "https://api.openweathermap.org/data/2.5/weather?";
            var latitude = "lat=37.76&";
            var longitude = "lon=144.96&";
            var apiKey = "appid=ac9f17c1797aeeab5ede29ce1b75fc4f";

            var endpoint = url + latitude + longitude + apiKey;
            try {
                using HttpResponseMessage response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);
                Console.WriteLine(response.StatusCode);
            } catch (HttpRequestException e){
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
