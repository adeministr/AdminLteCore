using System;
using System.Diagnostics;
using System.IO;

using Microsoft.AspNetCore.Mvc;

namespace Naitzel.Intranet.Application.AdminLte.ViewComponents
{
    public class ControlSidebarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string filter)
        {

            if (string.IsNullOrEmpty(ViewBag.PageHelpFileName))
            {
                return View(string.Empty);
            }

            ViewBag.PageHelpContainer = LoadFile(ViewBag.PageHelpFileName);

            return View();
        }

        private string LoadFile(string filepath)
        {
            var basePath = $"{Directory.GetCurrentDirectory()}\\wwwroot\\files\\";
            var baseExtension = @".html";
            var absoluteFilePath = basePath + filepath + baseExtension;

            string result = string.Empty;
            try
            {
                if (!File.Exists(absoluteFilePath))
                {
                    return string.Empty;
                }

                using(StreamReader sr = new StreamReader(new FileStream(absoluteFilePath, FileMode.Open, FileAccess.Read)))
                {
                    result = sr.ReadToEnd();
                }
            }
            catch (FileNotFoundException fex)
            {
                Debug.Write(fex);
                return string.Empty;
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
                return string.Empty;
            }

            return result;
        }
    }
}