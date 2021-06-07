using FireSafe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

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

        public async Task<IActionResult> Index()
        {
            LocationLists model = new LocationLists();
            var locations = new List<FireLocation>()
            {
                new FireLocation(1, "Cousso, Melgaco, Viana do Castelo","Incêndio Florestal", "42.064973", "-8.317543"),
            };
            model.FireLocationList = locations;
            //return View();
/*
            string apiResponse;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://api-dev.fogos.pt/new/fires"))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            ViewBag.apiResponse = apiResponse;
*/
            return View(model);
        }

        public IActionResult Init()
        {
            Localizacao.parseDataSet("DataSets/freguesias-metadata.json");

            return RedirectToAction("Index", "Home");
        }

        public IActionResult HomeLogado()
        {
            ViewBag.username = utililzadorAtual;

            LocationLists model = new LocationLists();
            var locations = new List<FireLocation>()
            {
                new FireLocation(1, "Cousso, Melgaco, Viana do Castelo","Incêndio Florestal", "42.064973", "-8.317543"),
            };
            model.FireLocationList = locations;
            //return View();
            /*
                        string apiResponse;
                        using (var httpClient = new HttpClient())
                        {
                            using (var response = await httpClient.GetAsync("https://api-dev.fogos.pt/new/fires"))
                            {
                                apiResponse = await response.Content.ReadAsStringAsync();
                            }
                        }

                        ViewBag.apiResponse = apiResponse;
            */
            return View(model);
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
