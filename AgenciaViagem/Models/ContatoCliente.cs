using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaViagem.Models
{
    public class ContatoCliente
    {
        [Key]
        public int Id_contato { get; set; }

        [Display(Name="Nome")]
        public String nome_contato { get; set; }

        [Display(Name="Sobrenome")]
        public String sobrenome_contato { get; set; }

        [Display(Name = "Telefone")]
        public String telefone_contato { get; set; }

        [Display(Name = "Cidade")]
        public String cidade_contato { get; set; }

        [Display(Name = "Região")]
        public String regiao_contato { get; set; }

        [Display(Name = "E-mail")]
        public String email_contato { get; set; }

        [Display(Name = "Motivo do contato")]
        public String motivo_contato { get; set; }
    }
}
