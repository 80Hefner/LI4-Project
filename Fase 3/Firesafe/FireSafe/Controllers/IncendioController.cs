using FireSafe.DatabaseAccess;
using FireSafe.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FireSafe.Controllers
{
    public class IncendioController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ConsultaDadosIncendioLogado(string id)
        {

            int idIncendio = Int32.Parse(id);
            IncendioDAO incendioDAO = new IncendioDAO();
            Incendio incendio = incendioDAO.FindIncendioById(idIncendio);

            ViewBag.Utilizador = HomeController.utililzadorAtual;

            ViewBag.NumeroIncendio = id;
            ViewBag.NumeroIncendioBD = incendio.ID_Incendio;
            ViewBag.Meios_Humanos = incendio.Meios_Humanos;
            ViewBag.Meios_Terrestres = incendio.Meios_Terrestres;
            ViewBag.Meios_Aereos = incendio.Meios_Aereos;

            return View(incendio);
        }

        public IActionResult ConsultaDadosIncendioDeslogado(string id)
        {

            int idIncendio = Int32.Parse(id);
            IncendioDAO incendioDAO = new IncendioDAO();
            Incendio incendio = incendioDAO.FindIncendioById(idIncendio);

            ViewBag.NumeroIncendio = id;
            ViewBag.NumeroIncendioBD = incendio.ID_Incendio;
            ViewBag.Meios_Humanos = incendio.Meios_Humanos;
            ViewBag.Meios_Terrestres = incendio.Meios_Terrestres;
            ViewBag.Meios_Aereos = incendio.Meios_Aereos;

            return View(incendio);
        }
    }
}
