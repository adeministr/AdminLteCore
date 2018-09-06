using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using Naitzel.Intranet.Domain.AdminLte.Helper;
using Naitzel.Intranet.Domain.AdminLte.ViewModel;

namespace Naitzel.Intranet.Application.AdminLte.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string filter)
        {
            var sidebars = new List<SidebarMenuViewModel>();

            sidebars.Add(ModuleHelper.AddHeader("MAIN NAVIGATION"));
            sidebars.Add(ModuleHelper.AddModule(ModuleHelper.Module.Home));

            sidebars.Last().TreeChild = new List<SidebarMenuViewModel>()
            {
                ModuleHelper.AddModule(ModuleHelper.Module.Login),
                ModuleHelper.AddModule(ModuleHelper.Module.Register, Tuple.Create(1, 1, 1)),
            };

            return View(sidebars);
        }
    }
}