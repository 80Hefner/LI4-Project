public class Localizacao
{
    public string Freguesia { get; set; }
    public string Concelho { get; set; }
    public string Distrito { get; set; }

    public Localizacao()
    {

    }

    public Localizacao(string freguesia, string concelho, string distrito)
    {
        this.Freguesia = freguesia;
        this.Concelho = concelho;
        this.Distrito = distrito;
    }
}