using System;
using System.Net.Http;
using System.Threading.Tasks;
using TheMaze.Utils;

namespace TheMaze.Core
{
    public class HttpClientEngine
    {
        public static HttpClient client;
        private string baseURL = "https://www.tvmaze.com/api";

        public HttpClientEngine(ILogger logger)
        {
            client = new HttpClient();
        }

        public void getGirlShows()
        {
            // https://api.tvmaze.com/search/shows?q=girls
        }

        static async Task Main()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }

    }
}
