﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Multas.Models
{
    public class Agentes
    {
        // id, nome, esquadra, foto

        public int ID { get; set; }

        public string Nome { get; set; }

        public string Esquadra { get; set; }

        public string Fotografia { get; set; }

        //identifica as multas passadasa pelo Agente
        public ICollection<Multas> ListaMultas { get; set; }
    }
}