using System.Collections.Generic;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository.Common;

namespace Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository.ReadOnly
{
    public interface IUserReadOnlyRepository : IReadOnlyRepository<User>
    {
        IEnumerable<User> AllRole(int id);
    }
}