using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using Naitzel.Intranet.Domain.AdminLte.Helper;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service;
using Naitzel.Intranet.Domain.AdminLte.ViewModel;

namespace Naitzel.Intranet.Application.AdminLte.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly IServiceProvider _serviceProvider;

        public SidebarViewComponent(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<IViewComponentResult> InvokeAsync(string filter)
        {
            // Cria lista do menu
            var menu = new List<SidebarMenuViewModel>();

            // Carrega todos os serviços que implementa a interface
            var services = _serviceProvider.GetServices<ISidebarService>();

            // Adiciona menu a lista
            foreach (ISidebarService service in services)
            {
                menu.AddRange(await service.Get());
            }

            // Adiciona primeiro menu
            menu.Add(ModuleHelper.AddHeader("MAIN NAVIGATION"));

            // Ordena a lista e retorna para view
            return View(menu.OrderBy(i => i.Order));
        }
    }
}