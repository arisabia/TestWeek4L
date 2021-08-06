using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TestWeek4L.Core.Model;

namespace TestWeek4L.Core.EF.Configurations
{
    public class OrdineConfiguration : IEntityTypeConfiguration<Ordine>
    {
        public void Configure(EntityTypeBuilder<Ordine> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.DataOrdine).IsRequired();

            builder.Property(c => c.CodiceOrdine)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.CodiceProdotto)
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(c => c.Importo)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.HasOne(c => c.Cliente)
                .WithMany(o => o.Ordini)
                .HasForeignKey(o => o.ClienteId);

        }
    }
}
