using Fase3.DatabseAccess;
using Fase3.Models;
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

        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                UtilizadorDAO userDAO = new UtilizadorDAO();
                int idUser = userDAO.LoginDAO(model.Email, model.Password);

                if (idUser != -1)
                {
                    Utilizador user = userDAO.FindUserByEmail(model.Email);
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, model.Email),
                        new Claim(ClaimTypes.Sid, idUser.ToString())
                    };
                    ClaimsIdentity identidadeUtilizador = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(identidadeUtilizador);

                    await HttpContext.SignInAsync(claimPrincipal);
                    return RedirectToAction("Index", "User", new { area = "" });
                }
            }
            ModelState.AddModelError("", "Wrong Email or Password");
            return View(model);
        }
    }
}
