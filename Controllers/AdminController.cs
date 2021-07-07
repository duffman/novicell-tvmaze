// /**
//  *
//  *  TvMazeWebApp
//  *   Written by Patrik Forsberg <patrik.forsberg@coldmind.com>
//  *   2021-07-07 04:07
//  *
//  */

using Microsoft.AspNetCore.Mvc;

namespace TvMazeWebApp.Controllers
{
	public class AdminController : Controller
	{
		// GET
		public IActionResult Index()
		{
			return View();
		}
	}
}