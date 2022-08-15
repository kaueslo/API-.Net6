using Domain.Enderecos;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.EntityConfig
{
    public class EnderecoConfig
    {
        #region Metodos
        public EnderecoConfig(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasMany(c => c.Clientes)
                .WithOne(x => x.Endereco)
                .HasForeignKey(c => c.Id);

            builder.Property(c => c.Rua)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(c => c.Numero)
                .IsRequired();

            builder.Property(c => c.CEP)
                .IsRequired()
                .HasMaxLength(8);
        }
        #endregion
    }
}
