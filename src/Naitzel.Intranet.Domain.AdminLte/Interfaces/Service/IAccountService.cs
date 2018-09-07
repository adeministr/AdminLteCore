using System.Threading;
using System.Threading.Tasks;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Validation;

namespace Naitzel.Intranet.Domain.AdminLte.Interfaces.Service
{
    public interface IAccountService
    {
        Task<ValidationResult> SignInAsync(string userName, string password, bool @isPersistent = false, CancellationToken cancellationToken = default(CancellationToken));

        Task SignOutAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<ValidationResult> RegisterAsync(User entity, CancellationToken cancellationToken = default(CancellationToken));

        Task<ValidationResult> UnregisterAsync(User entity, CancellationToken cancellationToken = default(CancellationToken));
    }
}