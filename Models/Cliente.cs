using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastrodeClientes.Models
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Nome Completo")]
        public String Nome { get; set; }
        [Display(Name = "Documento de Identificação")]
        public String Documento { get; set; }
        [Display(Name = "Tipo do Documento")]
        public String TipoDocumento { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime Nascimento { get; set; }
        [Display(Name = "CEP")]
        public String CEP { get; set; }
        [Display(Name = "Endereço")]
        public String Endereco { get; set; }
        [Display(Name = "Bairro")]
        public String Bairro { get; set; }
        [Display(Name = "Cidade")]
        public virtual Cidade Cidade { get; set; }
        [Display(Name = "Número do Telefone")]
        public String Telefone { get; set; }
        [Display(Name = " Número do Celular")]
        public String Celular { get; set; }
       
    }
}
