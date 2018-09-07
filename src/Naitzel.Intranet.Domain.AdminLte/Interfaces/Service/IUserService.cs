using System.Threading;
using System.Threading.Tasks;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service.Common;

namespace Naitzel.Intranet.Domain.AdminLte.Interfaces.Service
{
    public interface IUserService : IService<User>
    {
        Task<User> FindByEmailAsync(string param, CancellationToken cancellationToken = default(CancellationToken));

        Task<User> FindByLoginAsync(string param, CancellationToken cancellationToken = default(CancellationToken));

        Task<User> FindByNameAsync(string param, CancellationToken cancellationToken = default(CancellationToken));

        Task<User> FindByIdAsync(int id, CancellationToken cancellationToken = default(CancellationToken));
    }
}