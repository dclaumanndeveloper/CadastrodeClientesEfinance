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
        [Required(ErrorMessage = " O nome é um campo obrigatório", AllowEmptyStrings = false)]
        public String Nome { get; set; }
        [Display(Name = "Documento de Identificação")]
        [Required(ErrorMessage = " O documento é um campo obrigatório", AllowEmptyStrings = false)]
        public String Documento { get; set; }
        [Display(Name = "Tipo do Documento")]
        public Enums.TipoDocumento TipoDocumento { get; set; }
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = " A data de nascimento é um campo obrigatório", AllowEmptyStrings = false)]
        public DateTime Nascimento { get; set; }
        [Display(Name = "Sexo")]
        [Required(ErrorMessage = " O sexo é um campo obrigatório", AllowEmptyStrings = false)]
        public Enums.Sexo Sexo{get;set;}
        [Display(Name = "CEP")]
        public String CEP { get; set; }
        [Display(Name = "Endereço")]
        public String Endereco { get; set; }
        [Display(Name = "Bairro")]
        [Required(ErrorMessage = " O bairro é um campo obrigatório", AllowEmptyStrings = false)]
        public String Bairro { get; set; }
        [Display(Name = "Cidade")]
        [Required(ErrorMessage = " A cidade é um campo obrigatório", AllowEmptyStrings = false)]
        public virtual Cidade Cidade { get; set; }
        [Display(Name = "Número do Telefone")]
        public String Telefone { get; set; }
        [Display(Name = " Número do Celular")]
        public String Celular { get; set; }

    }
}
