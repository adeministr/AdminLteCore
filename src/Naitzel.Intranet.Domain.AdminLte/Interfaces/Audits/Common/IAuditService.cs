using System.Threading;
using System.Threading.Tasks;

namespace Naitzel.Intranet.Domain.AdminLte.Interfaces.Audits.Common
{
    public interface IAuditService<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
        Task UpdateAsync(TEntity oldEntity, TEntity newEntity, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));
    }
}