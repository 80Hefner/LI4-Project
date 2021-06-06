﻿using System;
using Fase3.DatabseAccess;
using Fase3.Models;

namespace Fase3.Models
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
    }
}