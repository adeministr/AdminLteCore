using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Naitzel.Intranet.Domain.AdminLte.Extension;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository.Common;
using Naitzel.Intranet.Infra.Data.AdminLte.Interfaces;

namespace Naitzel.Intranet.Infra.Data.AdminLte.Repository.Common
{
    public class Repository<TEntity> : ReadOnlyRepository<TEntity>, IRepository<TEntity>, IDisposable where TEntity : class
    {
        private readonly AdminLteContext _dbContext;

        public Repository(AdminLteContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        protected AdminLteContext GetContext()
        {
            return _dbContext;
        }

        public virtual Task AddAsync(TEntity entity, CancellationToken token = default(CancellationToken))
        {
            return _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken : token);
        }

        public virtual Task<IEnumerable<TEntity>> AllAsync(CancellationToken token = default(CancellationToken), bool @readonly = false)
        {
            return _dbContext.Set<TEntity>().ToListAsync(token).AsEnumerableAsync();
        }

        public virtual Task DeleteAsync(TEntity entity, CancellationToken token = default(CancellationToken))
        {
            _dbContext.Set<TEntity>().Remove(entity);

            return Task.CompletedTask;
        }

        public virtual Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default(CancellationToken), bool @readonly = false)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToListAsync(token).AsEnumerableAsync();
        }

        public virtual new Task<TEntity> GetAsync(int id, CancellationToken token = default(CancellationToken))
        {
            return _dbContext.Set<TEntity>().FindAsync(id, token);
        }

        public virtual Task UpdateAsync(TEntity entity, CancellationToken token = default(CancellationToken))
        {
            _dbContext.Set<TEntity>().Update(entity);

            return Task.CompletedTask;
        }

        public new void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}