using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Mapping
{

    class EscolaridadeMapping : IEntityTypeConfiguration<Escolaridade>
    {
        public void Configure(EntityTypeBuilder<Escolaridade> builder)
        {
            builder.ToTable("Escolaridades");

            builder.HasKey(c => c.Id);

            // builder.Property(c => c.Nome)
            //     .HasMaxLength(200)
            //     .IsRequired();

            // builder.Property(c => c.Telefone)
            //     .HasMaxLength(11);

            // builder.Property(c => c.CPF)
            //     .HasMaxLength(11)
            //     .IsRequired();

            // builder.Property(c => c.Email)
            //     .HasMaxLength(200);

            // builder.Property(c => c.Endereco)
            //     .HasMaxLength(500);

            // builder.Property(b => b.DataCadastramento)
            //     .HasDefaultValueSql("getdate()");
        }
    }
}