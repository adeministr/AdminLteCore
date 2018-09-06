using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using Naitzel.Intranet.Domain.AdminLte.ViewModel;

namespace Naitzel.Intranet.Application.AdminLte.ViewComponents
{
    public class MenuNotificationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string filter)
        {
            return View(new List<MessageViewModel>());
        }
    }
}