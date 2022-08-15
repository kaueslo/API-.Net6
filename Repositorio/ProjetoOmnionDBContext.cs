using Domain.Clientes;
using Domain.Contas;
using Domain.Enderecos;
using Domain.Telefones;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class ProjetoOmnionDBContext : DbContext
    {
        #region Propriedades

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Telefone> Telefone { get; set; }

        #endregion

        #region Construtores
        public ProjetoOmnionDBContext(DbContextOptions<ProjetoOmnionDBContext> options) : base(options)
        {

        }
        #endregion
    }
}
