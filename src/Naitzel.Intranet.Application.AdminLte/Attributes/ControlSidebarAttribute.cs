using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Naitzel.Intranet.Application.AdminLte.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ControlSidebarAttribute : ActionFilterAttribute, IActionFilter
    {
        private string _fileName { get; set; }
        private string _memberName { get; set; }
        private string _pageHelpFileName { get; set; }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            var controller = filterContext.Controller as Controller;
            controller.ViewBag.PageHelpFileName = _pageHelpFileName;
        }

        public ControlSidebarAttribute(string fileName = "", [CallerFilePath] string filePath = "", [CallerMemberName] string memberName = "")
        {
            var controllerName = filePath.Split('\\').Last().Replace("Controller.cs", string.Empty);
            if (fileName == string.Empty) //if not specified, will check it on the common help location plus path from class+method.html
            {
                _pageHelpFileName = $"{controllerName}\\{memberName}"; //ChildController + ActionMethod
            }
            else //if specified, will check it in the common help location
            {
                _pageHelpFileName = $"Shared\\{fileName}";
            }
        }
    }
}