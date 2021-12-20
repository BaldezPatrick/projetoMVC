using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgenciaViagem.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<CadastrarCliente> cadastrarClientes { get; set; }
        public DbSet<CompraCliente> compraClientes { get; set; }
        public DbSet<ContatoCliente> contatoClientes { get; set; }
    }
}
