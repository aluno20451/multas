using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Multas.Models
{
    public class Multas
    {
        // id, data, valor, infracao, FK viatura, FK agente, FK condutor

        public int ID { get; set; }

        public string Infracao { get; set; }

        [Display(Name = "Local da Multa")]
        public string LocalDaMulta { get; set; }

        [Display(Name = "Valor da Multa")]
        public decimal ValorMulta { get; set; }


        [Display(Name = "Data da Multa")]
        public DateTime DataDaMulta { get; set; }

        //CRIAR CHAVES FORASTEIRAS

        //FK para os Agentes
        [ForeignKey("Agente")]
        public int AgenteFK { get; set; }
        public virtual Agentes Agente { get; set; }
        
        //FK para os Condutores
        [ForeignKey("Condutor")]
        public int CondutorFK { get; set; }
        public virtual Condutores Condutor { get; set; }

        //FK para as viaturas
        [ForeignKey("Viatura")]
        public int ViaturaFK { get; set; }
        public virtual Viaturas Viatura { get; set; }

    }
}