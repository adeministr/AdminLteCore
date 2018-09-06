using System;
using System.Collections.Generic;

using Naitzel.Intranet.Domain.AdminLte.Enums;

namespace Naitzel.Intranet.Domain.AdminLte.Model
{
    public class SidebarMenu
    {
        public SidebarMenuType Type { get; set; }

        public bool IsActive { get; set; } = false;

        public string Name { get; set; }

        public string IconClassName { get; set; }

        public string URLPath { get; set; }

        public IList<SidebarMenu> TreeChild { get; set; }

        public Tuple<int, int, int> LinkCounter { get; set; }
    }
}