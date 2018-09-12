using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Naitzel.Intranet.Domain.AdminLte.Helper;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service;
using Naitzel.Intranet.Domain.AdminLte.ViewModel;

namespace Naitzel.Intranet.Application.AdminLte.Services
{
    public class SidebarService : ISidebarService
    {
        public Task<IEnumerable<SidebarMenuViewModel>> Get()
        {
            List<SidebarMenuViewModel> menu = new List<SidebarMenuViewModel>();

            menu.Add(ModuleHelper.AddModule(ModuleHelper.Module.Home));

            return Task.FromResult(menu.AsEnumerable());
        }
    }
}