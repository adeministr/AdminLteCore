using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Naitzel.Intranet.Domain.AdminLte.Entities;

namespace Naitzel.Intranet.Infra.Data.AdminLte.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.Property(p => p.FirstName).HasMaxLength(60).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(60).IsRequired();
            builder.Property(p => p.AvatarURL).HasMaxLength(200).HasDefaultValue(null);
        }
    }
}