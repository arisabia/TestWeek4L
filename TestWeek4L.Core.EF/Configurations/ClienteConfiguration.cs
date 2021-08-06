using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestWeek4L.Core.EF.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.ID);

            builder.Property(c => c.CodiceCliente)
                .HasMaxLength(7)
                .IsRequired();

            builder.Property(c => c.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.Cognome)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(c => c.Ordini)
                .WithOne(c => c.Cliente);
        }
    }
}
