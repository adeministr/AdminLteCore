using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository.Common;

namespace Naitzel.Intranet.Infra.Data.AdminLte.Repository.Common
{
    public class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity>, IDisposable where TEntity : class
    {
        private readonly AdminLteContext _dbContext;

        public ReadOnlyRepository(AdminLteContext dbContext) => _dbContext = dbContext;

        protected AdminLteContext Context => _dbContext;

        public virtual Task<IEnumerable<TEntity>> AllAsync(CancellationToken token = default(CancellationToken))
        {
            return Task.FromResult(_dbContext.Set<TEntity>().AsEnumerable());
        }

        public virtual Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default(CancellationToken))
        {
            return Task.FromResult(_dbContext.Set<TEntity>().Where(predicate).AsEnumerable());
        }

        public virtual Task<TEntity> GetAsync(int id, CancellationToken token = default(CancellationToken))
        {
            return Task.FromResult(_dbContext.Set<TEntity>().Find(id));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (Context == null) return;
            Context.Dispose();
        }
    }
}