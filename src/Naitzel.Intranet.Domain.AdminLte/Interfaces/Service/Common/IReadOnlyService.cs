using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Naitzel.Intranet.Domain.AdminLte.Interfaces.Service.Common
{
    public interface IReadOnlyService<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id, CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<TEntity>> AllAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken));
    }
}