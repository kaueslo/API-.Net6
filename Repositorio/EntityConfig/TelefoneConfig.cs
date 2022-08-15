using Domain.Telefones;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio.EntityConfig
{
    public class TelefonesConfig
    {
        #region Metodos
        public TelefonesConfig(EntityTypeBuilder<Telefone> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.Cliente)
                .WithMany(x => x.Telefones)
                .HasForeignKey(c => c.ClienteId);

            builder.Property(c => c.DDD)
                .IsRequired();

            builder.Property(c => c.Numero)
                .IsRequired();
        }
        #endregion
    }
}
