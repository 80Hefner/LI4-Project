public class Incendio
{
    public Localizacao localizacao { get; set; }
    public Meteorologia meteorologia { get; set; }
    public int Meios_Humanos { get; set; }
    public int Meios_Terrestres { get; set; }
    public int Meios_Aereos { get; set; }
    public int Estado { get; set; }
    public string Latitude { get; set; }
    public string Longitude { get; set; }

    public Incendio()
    {

    }

    public Incendio(Localizacao localizacao, Meteorologia meteorologia, int meios_humanos, int meios_terrestres, int meios_aereos, int estado, string latitude, string longitude)
    {
        this.localizacao = localizacao;
        this.meteorologia = meteorologia;
        this.Meios_Humanos = meios_humanos;
        this.Meios_Terrestres = meios_terrestres;
        this.Meios_Aereos = meios_aereos;
        this.Estado = estado;
        this.Latitude = latitude;
        this.Longitude = longitude;
    }
}