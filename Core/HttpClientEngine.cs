using System;
using System.Net.Http;
using System.Threading.Tasks;
using Coldmind.Utils;

namespace TheMaze.Core
{
    public class HttpClientEngine
    {
        private const string baseURL = "https://www.tvmaze.com/api";
        public static HttpClient client;

        public HttpClientEngine(IColdmindQLog logger)
        {
            client = new HttpClient();
        }

        public void getGirlShows()
        {
            // https://api.tvmaze.com/search/shows?q=girls
        }

        private static async Task Main()
        {
            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                var response = await client.GetAsync("http://www.contoso.com/");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
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