using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository.Common
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id, CancellationToken token = default(CancellationToken));
        Task<IEnumerable<TEntity>> AllAsync(CancellationToken token = default(CancellationToken));
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken token = default(CancellationToken));
    }
}