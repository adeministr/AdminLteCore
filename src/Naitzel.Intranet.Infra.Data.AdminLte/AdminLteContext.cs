using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Enums;
using Naitzel.Intranet.Infra.Data.AdminLte.Extension;
using Naitzel.Intranet.Infra.Data.AdminLte.Interfaces;

namespace Naitzel.Intranet.Infra.Data.AdminLte
{
    public class AdminLteContext : IdentityDbContext<User, Role, int>, IAdminLteContext
    {
        public DbSet<Message> Messages { get; set; }

        public DbSet<Audit> Audits { get; set; }

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