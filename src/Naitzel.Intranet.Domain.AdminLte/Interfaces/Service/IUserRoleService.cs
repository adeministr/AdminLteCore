using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Validation;

namespace Naitzel.Intranet.Domain.AdminLte.Interfaces.Service
{
    public interface IUserRoleService
    {
        Task<IEnumerable<Role>> AllAsync(User user, bool @readonly = false, CancellationToken cancellationToken = default(CancellationToken));

        Task<ValidationResult> AddAsync(User user, Role role, CancellationToken cancellationToken = default(CancellationToken));

        Task<ValidationResult> DeleteAsync(User user, Role role, CancellationToken cancellationToken = default(CancellationToken));
    }
}