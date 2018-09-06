using System;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Infra.Data.AdminLte.Extension;
using Naitzel.Intranet.Infra.Data.AdminLte.Interfaces;

namespace Naitzel.Intranet.Infra.Data.AdminLte
{
    public class AdminLteContext : IdentityDbContext<User, Role, int>, IAdminLteContext
    {
        public DbSet<Message> Messages { get; set; }

        public AdminLteContext() { }

        public AdminLteContext(DbContextOptions<AdminLteContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(databaseName: "AdminLte");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("dbo");
            builder.ApplyDefaultConfiguration<AdminLteContext>();
        }
    }
}