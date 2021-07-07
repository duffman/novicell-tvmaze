using Microsoft.AspNetCore.Mvc;
using TvMazeWebApp.DataProvider.ColdmindRestIgniter;

namespace TvMazeWebApp.Controllers
{
    public class StartController : Controller
    {
        public StartController(IColdmindRestClient restClient)
        {
            restClient.HelloWorld();
            var data = restClient.Retrieve("https://api.tvmaze.com/search/shows?q=girls", ColdmindRestClient.HttpMethod.Get);
            
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}