using System;
using Fase3.DatabseAccess;
using Fase3.Models;

namespace Fase3.Models
{
    public class Meteorologia
    {
        public int ID_Meteorologia { get; set; }
        public float Temp_atual { get; set; }
        public float Temp_min { get; set; }
        public float Temp_max { get; set; }
        public float Vento_vel { get; set; }
        public string Vento_dir { get; set; }
        public int Humidade { get; set; }
        public int Pressao_atm { get; set; }
        public string Estado { get; set; }

        public Meteorologia()
        {

        }

        public Meteorologia(int id, float temp_atual, float temp_min, float temp_max, float vento_vel, string vento_dir, int humidade, int pressao_atm, string estado)
        {
            this.ID_Meteorologia = id;
            this.Temp_atual = temp_atual;
            this.Temp_min = temp_min;
            this.Temp_max = temp_max;
            this.Vento_vel = vento_vel;
            this.Vento_dir = vento_dir;
            this.Humidade = humidade;
            this.Pressao_atm = pressao_atm;
            this.Estado = estado;
        }
    }
}