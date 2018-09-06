using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Naitzel.Intranet.Domain.AdminLte.Entities;

namespace Naitzel.Intranet.Infra.Data.AdminLte.Mapping
{
    public class MensagemMapping : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.ToTable("Mensagem");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.UserId).HasColumnType("int");
            builder.Property(p => p.Icon).HasColumnType("varchar(30)");
            builder.Property(p => p.ShortDesc).HasColumnType("varchar(255)");
            builder.Property(p => p.Body).HasColumnType("text");
            builder.Property(p => p.Date).HasColumnType("datetime2");
            builder.Property(p => p.Type).HasColumnType("tinyint");
            builder.Property(p => p.Status).HasColumnType("tinyint");
        }
    }
}