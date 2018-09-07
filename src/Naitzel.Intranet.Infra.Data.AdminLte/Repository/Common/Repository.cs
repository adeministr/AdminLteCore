using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Naitzel.Intranet.Domain.AdminLte.Extension;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Audits.Common;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository.Common;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service;
using Naitzel.Intranet.Infra.Data.AdminLte.Interfaces;

namespace Naitzel.Intranet.Infra.Data.AdminLte.Repository.Common
{
    public class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity>, IDisposable where TEntity : class
    {
        private readonly AdminLteContext _dbContext;

        private readonly IAuditService<TEntity> _audit;

        public Repository(IAuditService<TEntity> audit, AdminLteContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _audit = audit;
        }

        protected AdminLteContext GetContext => _dbContext;

        protected IAuditService<TEntity> GetAudit => _audit;

        public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken : cancellationToken);
            await _dbContext.SaveChangesAsync(true, cancellationToken);
            await _audit.AddAsync(entity, cancellationToken);
        }

        public virtual Task<IEnumerable<TEntity>> AllAsync(CancellationToken cancellationToken = default(CancellationToken), bool @readonly = false)
        {
            return _dbContext.Set<TEntity>().ToListAsync(cancellationToken).AsEnumerableAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync(true, cancellationToken);
            await _audit.DeleteAsync(entity, cancellationToken);
        }

        public virtual Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken), bool @readonly = false)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToListAsync(cancellationToken).AsEnumerableAsync();
        }

        public virtual new Task<TEntity> GetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _dbContext.Set<TEntity>().FindAsync(id, cancellationToken);
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            _dbContext.Set<TEntity>().Update(entity);
            var oldValues = await _dbContext.Set<TEntity>().FindAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(true, cancellationToken);
            await _audit.UpdateAsync(oldValues, entity, cancellationToken);
        }

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}