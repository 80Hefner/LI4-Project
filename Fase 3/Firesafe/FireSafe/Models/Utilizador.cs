using System;
using Fase3.DatabseAccess;
using Fase3.Models;

namespace Fase3.Models
{
    public class Utilizador
    {
        public int ID_Utilizador { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Telemovel { get; set; }

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
        }
    }
}