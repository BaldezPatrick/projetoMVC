using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaViagem.Models
{
    public class CompraCliente
    {
        [Key]
        public int Id_compra { get; set; }

        [Display(Name="Nome")]
        public String nome_cliente { get; set; }

        [Display(Name="Sobrenome")]
        public String sobrenome_cliente { get; set; }

        [Display(Name = "Local de partida")]
        public String local_partida { get; set; }

        [Display(Name = "Local de chegada")]
        public String local_chegada { get; set; }

        [Display(Name = "Ida")]
        public DateTime dia_ida { get; set; }

        [Display(Name = "Volta")]
        public DateTime dia_chegada { get; set; }

        [Display(Name = "Quantidade de passagem")]
        public int qtd_passagem { get; set; }

        [Display(Name = "Nº do assento")]
        public int num_assento { get; set; }
    }
}
