using FireSafe.DatabaseAccess;
using FireSafe.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FireSafe.Controllers
{
    public class UtilizadorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UtilizadorDAO userDAO = new UtilizadorDAO();
                int idUser = userDAO.LoginDAO(model.Email, model.Password);

                if (idUser != -1)
                {
                    return RedirectToAction("Index", "Utilizador");
                }
            } else
            {
                ModelState.AddModelError("", "Wrong Email or Password");
            }
            return View(model);
        }
    }
}
