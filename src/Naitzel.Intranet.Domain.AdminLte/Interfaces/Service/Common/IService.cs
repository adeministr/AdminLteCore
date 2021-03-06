using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Naitzel.Intranet.Domain.AdminLte.Validation;

namespace Naitzel.Intranet.Domain.AdminLte.Interfaces.Service.Common
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(int id, CancellationToken cancellationToken = default(CancellationToken), bool @readonly = false);
        Task<IEnumerable<TEntity>> AllAsync(CancellationToken cancellationToken = default(CancellationToken), bool @readonly = false);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken), bool @readonly = false);
        Task<ValidationResult> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        Task<ValidationResult> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        Task<ValidationResult> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
    }
}