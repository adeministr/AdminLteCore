using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using Naitzel.Intranet.Domain.AdminLte.ViewModel;

namespace Naitzel.Intranet.Application.AdminLte.ViewComponents
{
    public class PageAlertViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string filter)
        {
            List<MessageViewModel> messages;

            if (ViewBag.PageAlerts == null)
            {
                messages = new List<MessageViewModel>();
            }
            else
            {
                messages = new List<MessageViewModel>(ViewBag.PageAlerts);
            }

            return View(messages);
        }
    }
}