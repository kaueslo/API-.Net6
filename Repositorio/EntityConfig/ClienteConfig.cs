using Domain.Clientes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.EntityConfig
{
    public class ClienteConfig
    {
        #region Construtores
        public ClienteConfig(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(14);

            builder.Property(c => c.DataCadastro)
                .IsRequired();

            builder.Property(c => c.DataAlteracao)
                .IsRequired();
        }
        #endregion
    }
}
