using Domain.Contas;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.EntityConfig
{
    public class ContasConfig
    {
        #region Construtores
        public ContasConfig(EntityTypeBuilder<Conta> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Clientes)
                .WithOne(x => x.Conta)
                .HasForeignKey(c => c.Id);

            builder.Property(c => c.SaldoPontos)
                .IsRequired();
        }
        #endregion
    }
}
