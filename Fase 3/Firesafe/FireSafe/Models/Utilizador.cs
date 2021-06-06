using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Fase3.DatabseAccess;
using Fase3.Models;
using FireSafe.DatabaseAccess;

namespace Fase3.Models
{
    public class Utilizador
    {
        public LocalizacaoDAO LocalizacaoDAO = new LocalizacaoDAO();
        public int ID_Utilizador { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Telemovel { get; set; }
        public List<Localizacao> localizacoesFavoritas { get; set; }

        public Utilizador()
        {

        }

        public Utilizador(int id, string username, string password, string email, string telemovel)
        {
            this.ID_Utilizador = id;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Telemovel = telemovel;
            this.localizacoesFavoritas = null;
        }

        public Utilizador(int id, string username, string password, string email, string telemovel, List<Localizacao> locFavoritas)
        {
            this.ID_Utilizador = id;
            this.Username = username;
            this.Password = password;
            this.Email = email;
            this.Telemovel = telemovel;
            this.localizacoesFavoritas = locFavoritas;
        }
    }


    public class LoginModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}