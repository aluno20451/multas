﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Multas.Models
{
    public class MultasDB : DbContext{

        public MultasDB():base("MultasConnectionString") {
        }

        //especificar tabelas da BD
        public DbSet<Agentes> Agentes { get; set; }

        public DbSet<Condutores> Condutores { get; set; }

        public DbSet<Viaturas> Viaturas { get; set; }

        public DbSet<Multas> Multas { get; set; }
    }
}