using System;

using Naitzel.Intranet.Domain.AdminLte.Enums;
using Naitzel.Intranet.Domain.AdminLte.ViewModel;

namespace Naitzel.Intranet.Domain.AdminLte.Helper
{
    public static class ModuleHelper
    {
        public enum Module
        {
            Home,
            About,
            Contact,
            Error,
            Login,
            Register,
        }

        public static SidebarMenuViewModel AddHeader(string name)
        {
            return new SidebarMenuViewModel
            {
                Type = SidebarMenuType.Header,
                    Name = name,
            };
        }

        public static SidebarMenuViewModel AddTree(string name, string iconClassName = "fa fa-link")
        {
            return new SidebarMenuViewModel
            {
            Type = SidebarMenuType.Tree,
            IsActive = false,
            Name = name,
            IconClassName = iconClassName,
            URLPath = "#",
            };
        }

        public static SidebarMenuViewModel AddModule(Module module, Tuple<int, int, int> counter = null)
        {
            if (counter == null)
                counter = Tuple.Create(0, 0, 0);

            switch (module)
            {
                case Module.Home:
                    return new SidebarMenuViewModel
                    {
                        Type = SidebarMenuType.Link,
                            Name = "Home",
                            IconClassName = "fa fa-link",
                            URLPath = "/",
                            LinkCounter = counter,
                    };
                case Module.Login:
                    return new SidebarMenuViewModel
                    {
                        Type = SidebarMenuType.Link,
                            Name = "Login",
                            IconClassName = "fa fa-sign-in",
                            URLPath = "/Account/Login",
                            LinkCounter = counter,
                    };
                case Module.Register:
                    return new SidebarMenuViewModel
                    {
                        Type = SidebarMenuType.Link,
                            Name = "Register",
                            IconClassName = "fa fa-user-plus",
                            URLPath = "/Account/Register",
                            LinkCounter = counter,
                    };
                case Module.About:
                    return new SidebarMenuViewModel
                    {
                        Type = SidebarMenuType.Link,
                            Name = "About",
                            IconClassName = "fa fa-group",
                            URLPath = "/Home/About",
                            LinkCounter = counter,
                    };
                case Module.Contact:
                    return new SidebarMenuViewModel
                    {
                        Type = SidebarMenuType.Link,
                            Name = "Contact",
                            IconClassName = "fa fa-phone",
                            URLPath = "/Home/Contact",
                            LinkCounter = counter,
                    };
                case Module.Error:
                    return new SidebarMenuViewModel
                    {
                        Type = SidebarMenuType.Link,
                            Name = "Error",
                            IconClassName = "fa fa-warning",
                            URLPath = "/Home/Error",
                            LinkCounter = counter,
                    };

                default:
                    break;
            }

            return null;
        }
    }
}