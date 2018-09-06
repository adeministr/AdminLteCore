using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using Naitzel.Intranet.Domain.AdminLte.ViewModel;

namespace Naitzel.Intranet.Application.AdminLte.ViewComponents
{
    public class BreadcrumbViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string filter)
        {
            if (ViewBag.Breadcrumb == null)
            {
                ViewBag.Breadcrumb = new List<MessageViewModel>();
            }

            return View(ViewBag.Breadcrumb as List<MessageViewModel>);
        }
    }
}