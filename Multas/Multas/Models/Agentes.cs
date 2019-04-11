using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Multas.Models
{
    public class Agentes
    {
        // id, nome, esquadra, foto

        public int ID { get; set; }

        [Required(ErrorMessage ="Por favor escrevo o nome do Agente")]
        [RegularExpression("([A - ZÁÉÍÓÚa - záéíóúàèìòùâêîôûçñ] + ( | -| ')?)+", ErrorMessage = "Só pode escrever letras no nome")]



        public string Nome { get; set; }

        [Required(ErrorMessage = "Não se esqueça de indicar a Esquadra onde o agente trabalha, por favor")]
        public string Esquadra { get; set; }

        public string Fotografia { get; set; }

        //identifica as multas passadasa pelo Agente
        public ICollection<Multas> ListaMultas { get; set; }
    }
}