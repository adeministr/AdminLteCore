using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Naitzel.Intranet.Application.AdminLte.Attributes;
using Naitzel.Intranet.Application.AdminLte.Models;

namespace Naitzel.Intranet.Application.AdminLte.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        public IActionResult Index([FromServices] Domain.AdminLte.Interfaces.Service.IMessageService service)
        {
            var message = new Domain.AdminLte.Entities.Message();
            message.UserId = 1;
            message.Icon = "fa fa-icon";
            message.ShortDesc = "descrica dfa dfasd o";
            message.Type = Domain.AdminLte.Enums.MessageType.Information;
            message.Status = Domain.AdminLte.Enums.MessageStatusType.Opened;
            message.Body = "aa dfasdf asdfas fasd fasd  fasdf asdf asdf fsdf";
            message.Percentage = 30;

            service.AddAsync(message);

            AddPageHeader("Dashboard", "");
            return View();
        }

        public IActionResult About()
        {
            AddBreadcrumb("About", "/Account/About");
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            AddBreadcrumb("Register", "/Account/Register");
            AddBreadcrumb("Contact", "/Account/Contact");
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}