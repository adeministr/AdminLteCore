using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Naitzel.Intranet.Domain.AdminLte.Enums;
using Naitzel.Intranet.Domain.AdminLte.Helper;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service;
using Naitzel.Intranet.Domain.AdminLte.ViewModel;

namespace Naitzel.Intranet.Infra.Security.AdminLte.Service
{
    public class SidebarService : ISidebarService
    {
        public Task<IEnumerable<SidebarMenuViewModel>> Get()
        {
            List<SidebarMenuViewModel> menu = new List<SidebarMenuViewModel>();

            var settings = ModuleHelper.AddModule(ModuleHelper.Module.Setting);

            settings.TreeChild.Add(ModuleHelper.AddModule(ModuleHelper.Module.User));
            settings.TreeChild.Add(ModuleHelper.AddModule(ModuleHelper.Module.Role));

            menu.Add(settings);
            return Task.FromResult(menu.AsEnumerable());
        }
    }
}