using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Naitzel.Intranet.Domain.AdminLte.ViewModel;

namespace Naitzel.Intranet.Application.AdminLte.Controllers
{
    public abstract class BaseController : Controller
    {
        internal void AddBreadcrumb(string displayName, string urlPath)
        {
            List<MessageViewModel> messages;

            if (ViewBag.Breadcrumb == null)
            {
                messages = new List<MessageViewModel>();
            }
            else
            {
                messages = ViewBag.Breadcrumb as List<MessageViewModel>;
            }

            messages.Add(new MessageViewModel { DisplayName = displayName, URLPath = urlPath });
            ViewBag.Breadcrumb = messages;
        }

        internal void AddPageHeader(string pageHeader = "", string pageDescription = "")
        {
            ViewBag.PageHeader = Tuple.Create(pageHeader, pageDescription);
        }

        internal enum PageAlertType
        {
            Error,
            Info,
            Warning,
            Success
        }

        internal void AddPageAlerts(PageAlertType pageAlertType, string description)
        {
            List<MessageViewModel> messages;

            if (ViewBag.PageAlerts == null)
            {
                messages = new List<MessageViewModel>();
            }
            else
            {
                messages = ViewBag.PageAlerts as List<MessageViewModel>;
            }

            messages.Add(new MessageViewModel { Type = pageAlertType.ToString().ToLower(), ShortDesc = description });
            ViewBag.PageAlerts = messages;
        }
    }
}