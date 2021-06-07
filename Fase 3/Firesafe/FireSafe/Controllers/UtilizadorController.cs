using FireSafe.DatabaseAccess;
using FireSafe.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
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

        public IActionResult Perfil()
        {
            UtilizadorDAO userDAO = new UtilizadorDAO();
            Utilizador utilizador = userDAO.FindUserByName(HomeController.utililzadorAtual);

            ViewBag.NomeUtilizador = utilizador.Username;
            ViewBag.EmailUtilizador = utilizador.Email;
            ViewBag.NumeroTelemovel = utilizador.Telemovel;

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
                    Utilizador utilizador = userDAO.FindUserById(idUser);

                    HomeController.utililzadorAtual = utilizador.Username;

                    return RedirectToAction("HomeLogado", "Home");
                }
            } else
            {
                ModelState.AddModelError("", "Wrong Email or Password");
            }
            return View(model);
        }


        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (string.Equals(model.Password,model.PasswordConfirm))
                {
                    UtilizadorDAO userDAO = new UtilizadorDAO();
                    Utilizador novoUser = new Utilizador(-1, model.Username, model.Password, model.Email, model.Telemovel);

                    bool adicionado = userDAO.insereNovoUtilizador(novoUser);

                    if (adicionado)
                    {
                        return RedirectToAction("Login", "Utilizador");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Cardencials already exist");
                    }
                }
            }
            return View(model);
        }


    }
}
