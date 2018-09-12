using System;
using System.Collections.Generic;

using Naitzel.Intranet.Domain.AdminLte.Enums;
using Naitzel.Intranet.Domain.AdminLte.ViewModel;

namespace Naitzel.Intranet.Domain.AdminLte.Helper
{
    public static class ModuleHelper
    {
        public enum Module
        {
            Home,
            Setting,
            User,
            Role,
        }

        public static SidebarMenuViewModel AddHeader(string name)
        {
            var menu = new SidebarMenuViewModel
            {
                Type = SidebarMenuType.Header,
                Name = name,
                Order = 0,
            };

            return menu;
        }

        public static SidebarMenuViewModel AddTree(string name)
        {
            var menu = new SidebarMenuViewModel
            {
                Type = SidebarMenuType.Tree,
                IsActive = false,
                Name = name,
                URLPath = "#",
                IconClassName = "fa fa-link"
            };

            return menu;
        }

        public static SidebarMenuViewModel AddTree(string name, string icon)
        {
            var menu = AddTree(name);
            menu.IconClassName = icon;
            return menu;
        }

        public static SidebarMenuViewModel AddModule(Module module, Tuple<int, int, int> counter = null)
        {
            if (counter == null) counter = Tuple.Create(0, 0, 0);

            SidebarMenuViewModel menu = null;

            switch (module)
            {
                case Module.Home:
                    menu = new SidebarMenuViewModel
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Home",
                        IconClassName = "fa fa-link",
                        URLPath = "/",
                        LinkCounter = counter,
                        Order = 2,
                    };
                    break;

                case Module.Setting:
                    menu = new SidebarMenuViewModel
                    {
                        Type = SidebarMenuType.Tree,
                        IsActive = false,
                        Name = "Sistema",
                        IconClassName = "fa fa-sliders",
                        URLPath = "#",
                        TreeChild = new List<SidebarMenuViewModel>(),
                        Order = 200
                    };
                    break;

                case Module.User:
                    menu = new SidebarMenuViewModel
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Usuários",
                        IconClassName = "fa fa-user-circle-o",
                        URLPath = "/Identity/User/Index",
                        LinkCounter = Tuple.Create(0, 0, 0),
                    };
                    break;

                case Module.Role:
                    menu = new SidebarMenuViewModel
                    {
                        Type = SidebarMenuType.Link,
                        Name = "Funções",
                        IconClassName = "fa fa-tags",
                        URLPath = "/Home/About",
                        LinkCounter = Tuple.Create(0, 0, 0),
                    };
                    break;

                default:
                    break;
            }

            return menu;
        }
    }
}