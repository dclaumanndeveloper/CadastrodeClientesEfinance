using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrodeClientes.Models
{
    public class Estado
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "IBGE")]
        public String CodigoIBGE { get; set; }
        [Display(Name = "Estado")]
        public String Nome { get; set; }
        [Display(Name = "Sigla")]
        public string Sigla { get; set; }
        [Display(Name = "Status")]
        public char Ativo { get; set; }
    }
}
