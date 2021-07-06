/**
 * 
 *  Written by Patrik Forsberg 2021 <patrik.forsberg@coldmind.com>
 *  This file is part of the TVNaze work sample project for Novicell
 *  
 */

using Microsoft.AspNetCore.Mvc;
using TheMaze.Utils;

namespace TheMaze.Controllers
{
    [ApiController]
    public class TvShowsController : ControllerBase
    {
        public TvShowsController(ILogger logger)
        {

        }


        [HttpGet("shows/all")]
        public void getShows()
        {

        }
    }
}
