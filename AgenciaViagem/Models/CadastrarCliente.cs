using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaViagem.Models
{
    public class CadastrarCliente
    {
        [Key]
        public int Id_cliente { get; set; }

        [Display(Name = "Nome")]
        public String nome_cliente { get; set; }

        [Display(Name = "Sobrenome")]
        public String sobrenome_cliente { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime data_nasc_cliente { get; set; }

        [Display(Name = "Endereço")]
        public String endereco_cliente { get; set; }

        [Display(Name = "Telefone")]
        public String telefone_cliente { get; set; }

        [Display(Name = "Cidade")]
        public String cidade_cliente { get; set; }

        [Display(Name = "E-mail")]
        public String email_cliente { get; set; }
        
    }
}
