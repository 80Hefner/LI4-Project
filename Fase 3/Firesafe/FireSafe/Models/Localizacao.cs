using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using FireSafe.DatabaseAccess;
using FireSafe.Models;

namespace FireSafe.Models
{
    public class Localizacao
    {
        public int ID_Localizacao { get; set; }
        public string Freguesia { get; set; }
        public string Concelho { get; set; }
        public string Distrito { get; set; }

        public Localizacao()
        {

        }

        public Localizacao(int id, string freguesia, string concelho, string distrito)
        {
            this.ID_Localizacao = id;
            this.Freguesia = freguesia;
            this.Concelho = concelho;
            this.Distrito = distrito;
        }

        public static void parseDataSet(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            LocalizacoesDataSet local = JsonSerializer.Deserialize<LocalizacoesDataSet>(jsonString);

            LocalizacaoDAO locDAO = new LocalizacaoDAO();
            foreach (LocalizacaoDataSet l in local.d)
            {
                string distrito = l.distrito;
                string concelho = l.concelho;
                string freguesia = l.freguesia;

                bool res = locDAO.insereLocalizacao(distrito, concelho, freguesia);

                if (!res)
                {
                    Console.WriteLine($"Localização já existente: Distrito = {distrito}, Concelho = {concelho}, Freguesia = {freguesia}");
                }
            }
        }

        
    }

    [Serializable]
    public class LocalizacaoDataSet
    {
        public string PartitionKey { get; set; }
        public string nivel { get; set; }
        public string distrito { get; set; }
        public string concelho { get; set; }
        public string freguesia { get; set; }
        public string dicofre { get; set; }
        public string brasao { get; set; }
    }

    [Serializable]
    public class LocalizacoesDataSet
    {
        public List<LocalizacaoDataSet> d { get; set; }
    }
}