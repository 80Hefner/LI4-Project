using System;
using FireSafe.DatabaseAccess;
using FireSafe.Models;

namespace FireSafe.Models
{
    public class Incendio
    {
        public LocalizacaoDAO LocalizacaoDAO = new LocalizacaoDAO();
        
        public MeteorologiaDAO MeteorologiaDAO = new MeteorologiaDAO();

        public int ID_Incendio { get; set; }
        public Localizacao localizacao { get; set; }
        public Meteorologia meteorologia { get; set; }
        public int Meios_Humanos { get; set; }
        public int Meios_Terrestres { get; set; }
        public int Meios_Aereos { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int Estado { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }

        public Incendio()
        {

        }

        public Incendio(int id, int meios_humanos, int meios_terrestres, int meios_aereos, float latitude, float longitude, int estado, DateTime inicio, DateTime fim)
        {
            this.ID_Incendio = id;
            this.localizacao = null;
            this.meteorologia = null;
            this.Meios_Humanos = meios_humanos;
            this.Meios_Terrestres = meios_terrestres;
            this.Meios_Aereos = meios_aereos;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Estado = estado;
            this.Inicio = inicio;
            this.Fim = fim;
        }

        public Incendio(int id, Localizacao localizacao, Meteorologia meteorologia, int meios_humanos, int meios_terrestres, int meios_aereos, float latitude, float longitude, int estado, DateTime inicio, DateTime fim)
        {
            this.ID_Incendio = id;
            this.localizacao = localizacao;
            this.meteorologia = meteorologia;
            this.Meios_Humanos = meios_humanos;
            this.Meios_Terrestres = meios_terrestres;
            this.Meios_Aereos = meios_aereos;
            this.Estado = estado;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Inicio = inicio;
            this.Fim = fim;
        }
    }
}