using Microsoft.AspNetCore.Mvc;

namespace Naitzel.Intranet.Application.AdminLte.ViewComponents
{
    public class MenuUserViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string filter)
        {
            return View();
        }
    }
}