using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelfServices.API.Controllers
{
    [Route("api/home")]
    [ApiController]
    public class HomeController
    {
        public HomeController()
        {
        }

        [HttpGet]
        public string home()
        {
            return "Welcome To our Api , thanks for using it ";
        }

    }
}
