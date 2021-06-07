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
                new FireLocation(1, "Amares","Descrição bonita de Ferreiros", "41.633643", "-8.351730"),
                new FireLocation(2, "Hyderabad","Hyderabad, Telengana", "0","0" ),
                new FireLocation(3, "Bengaluru","Bengaluru, Karnataka", "12.99", "77.5"),
                new FireLocation(4, "Bhubaneswar","Bhubaneswar, Odisha", "20.001", "85")
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
