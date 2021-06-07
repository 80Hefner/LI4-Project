using FireSafe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FireSafe.Controllers
{
    public class HomeController : Controller
    {
        public static string utililzadorAtual = "";

        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            LocationLists model = new LocationLists();
            var locations = new List<FireLocation>()
            {
                new FireLocation(1, "Amares","Descrição bonita de Ferreiros", 41.65, -8.3667),
                new FireLocation(2, "Hyderabad","Hyderabad, Telengana", 17.387140, 78.491684),
                new FireLocation(3, "Bengaluru","Bengaluru, Karnataka", 12.972442, 77.580643),
                new FireLocation(4, "Bhubaneswar","Bhubaneswar, Odisha", 20.296059, 85.824539)
            };
            model.FireLocationList = locations;
            return View(model);
            //return View();
        }

        public IActionResult HomeLogado()
        {
            ViewBag.username = utililzadorAtual;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
