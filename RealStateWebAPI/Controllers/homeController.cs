using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RealStateWebAPI.Controllers
{
    public class homeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}