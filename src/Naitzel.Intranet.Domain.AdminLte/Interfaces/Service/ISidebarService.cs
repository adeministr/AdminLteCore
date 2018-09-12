using System.Collections.Generic;
using System.Threading.Tasks;

using Naitzel.Intranet.Domain.AdminLte.ViewModel;

namespace Naitzel.Intranet.Domain.AdminLte.Interfaces.Service
{
    public interface ISidebarService
    {
        Task<IEnumerable<SidebarMenuViewModel>> Get();
    }
}