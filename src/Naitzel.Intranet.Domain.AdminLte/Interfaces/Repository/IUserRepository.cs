using System.Collections.Generic;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository.Common;

namespace Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> AllRole(int id, bool @readonly = false);
    }
}