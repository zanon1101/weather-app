using System;
using System.Net.Http;
using Newtonsoft.Json;

namespace weather_app_dotnet {

    class Program {
    static readonly HttpClient client = new HttpClient();
        static async System.Threading.Tasks.Task Main(string[] args){
            DotNetEnv.Env.Load();

            var latitude = "lat=37.76&";
            var longitude = "lon=144.96&";

            string url = Environment.GetEnvironmentVariable("API_URL");
            string apiKey = Environment.GetEnvironmentVariable("API_KEY");

            var endpoint = url + latitude + longitude + apiKey;

            Console.WriteLine($"*** Fetching weather data for lat: {latitude} long: {longitude} ***");
            try {
                using HttpResponseMessage response = await client.GetAsync(endpoint);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                var parsedJson = JsonConvert.DeserializeObject(responseBody);

                Console.WriteLine(parsedJson);

            } catch (HttpRequestException e){
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }
    }
}
