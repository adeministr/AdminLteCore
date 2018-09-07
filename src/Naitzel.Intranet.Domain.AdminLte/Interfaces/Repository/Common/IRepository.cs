using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository.Common
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        Task<TEntity> GetAsync(int id, CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<TEntity>> AllAsync(CancellationToken cancellationToken = default(CancellationToken), bool @readonly = false);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken), bool @readonly = false);
    }
}