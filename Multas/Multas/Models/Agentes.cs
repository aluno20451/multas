using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Multas.Models
{
    public class Agentes
    {
        public Agentes() {
            ListaMultas = new HashSet<Multas>();
        }
        // id, nome, esquadra, foto

        public int ID { get; set; }

        [Required(ErrorMessage ="Por favor escrevo o nome do Agente")]
        [StringLength(40)]
        [RegularExpression("[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]+(( | e | de | da | das | do | dos |-|'|d')[A-ZÁÉÍÓÚÂ][a-záéíóúàèìòùäëïöüãõâêîôûçñ]*){1,3}",
                           ErrorMessage = "só são aceites palavras, começadas por Maiúscula, " +
                                         "separadas por um espeço em branco.")]



        public string Nome { get; set; }

        [Required(ErrorMessage = "Não se esqueça de indicar a Esquadra onde o agente trabalha, por favor")]
        public string Esquadra { get; set; }

        public string Fotografia { get; set; }

        //identifica as multas passadasa pelo Agente
        public virtual ICollection<Multas> ListaMultas { get; set; }
    }
}