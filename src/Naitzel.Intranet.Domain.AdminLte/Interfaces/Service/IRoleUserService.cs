using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Validation;

namespace Naitzel.Intranet.Domain.AdminLte.Interfaces.Service
{
    public interface IRoleUserService
    {
        Task<IEnumerable<User>> AllAsync(Role role, bool @readonly = false, CancellationToken cancellationToken = default(CancellationToken));

        Task<ValidationResult> AddAsync(Role role, User user, CancellationToken cancellationToken = default(CancellationToken));

        Task<ValidationResult> DeleteAsync(Role role, User user, CancellationToken cancellationToken = default(CancellationToken));
    }
}