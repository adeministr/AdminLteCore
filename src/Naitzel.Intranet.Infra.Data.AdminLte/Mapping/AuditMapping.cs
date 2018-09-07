using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Naitzel.Intranet.Domain.AdminLte.Entities;

namespace Naitzel.Intranet.Infra.Data.AdminLte.Mapping
{
    public class AuditMapping : IEntityTypeConfiguration<Audit>
    {
        public void Configure(EntityTypeBuilder<Audit> builder)
        {
            builder.ToTable("AuditLog");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.AuditType).HasColumnType("char(1)");
            builder.Property(p => p.TableName).HasColumnType("nvarchar(150)");
            builder.Property(p => p.KeyValue).HasColumnType("nvarchar(100)");
            builder.Property(p => p.OldValue).HasColumnType("nvarchar(max)");
            builder.Property(p => p.NewValue).HasColumnType("nvarchar(max)");
            builder.Property(p => p.Date).HasColumnType("datetime2");
            builder.Property(p => p.UserId).HasColumnType("int");
        }
    }
}