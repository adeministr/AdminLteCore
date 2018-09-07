using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Dapper;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Enums;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Audits.Common;

using Newtonsoft.Json;

namespace Naitzel.Intranet.Infra.Data.AdminLte.Audits.Common
{
    public class AuditService<TEntity> : IAuditService<TEntity> where TEntity : class
    {
        private readonly AdminLteContext _context;

        public AuditService(AdminLteContext context) => _context = context;

        public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.CompletedTask;
        }

        public Task UpdateAsync(TEntity oldEntity, TEntity newEntity, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.CompletedTask;
        }

        // private Task AddAudit(AuditType type, TEntity oldEntity = null, TEntity newEntity = null)
        // {
        //     // using(var scope = _service.CreateScope())
        //     // using(var context = scope.ServiceProvider.GetService<AdminLteContext>())
        //     // {
        //     // var entityType = _context.Model.FindEntityType(typeof(TEntity));
        //     // var mapping = entityType.Relational();
        //     // var schema = mapping.Schema;
        //     // var tableName = mapping.TableName;
        //     // var KeyValues = entityType.FindPrimaryKey().Properties.Select(i =>
        //     // {
        //     //     var entity = oldEntity == null ? newEntity : oldEntity;
        //     //     return new KeyValuePair<string, string>(i.Name, entity.GetType().GetProperty(i.Name).GetValue(entity, null).ToString());
        //     // });

        //     // var audit = new Audit();
        //     // audit.AuditType = type;
        //     // audit.TableName = $"{schema}.{tableName}";
        //     // audit.KeyValue = JsonConvert.SerializeObject(KeyValues);
        //     // audit.OldValue = oldEntity == null ? null : JsonConvert.SerializeObject(oldEntity);
        //     // audit.NewValue = newEntity == null ? null : JsonConvert.SerializeObject(newEntity);
        //     // audit.Date = DateTime.Now;
        //     // audit.UserId = 1;

        //     // _context.Audits.Add(audit);
        //     // _context.SaveChanges();

        //     return Task.CompletedTask;

        //     // var config = scope.ServiceProvider.GetService<IConfiguration>();
        //     // using(SqlConnection conexao = new SqlConnection(config.GetConnectionString("DefaultConnection")))
        //     // {
        //     //     conexao.Execute("INSERT AuditLog (AuditType, TableName, KeyValue, OldValue, NewValue, Date, UserId) VALUES (@AuditType, @TableName, @KeyValue, @OldValue, @NewValue, @Date, @UserId)", audit);
        //     // }
        //     // }
        //     // return Task.CompletedTask;
        // }
    }
}