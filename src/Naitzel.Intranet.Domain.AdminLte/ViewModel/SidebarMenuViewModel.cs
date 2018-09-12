using System;
using System.Collections.Generic;

using Naitzel.Intranet.Domain.AdminLte.Enums;

namespace Naitzel.Intranet.Domain.AdminLte.ViewModel
{
    public class SidebarMenuViewModel
    {
        public SidebarMenuType Type { get; set; }

        public bool IsActive { get; set; } = false;

        public string Name { get; set; }

        public string IconClassName { get; set; }

        public string URLPath { get; set; }

        public IList<SidebarMenuViewModel> TreeChild { get; set; } = new List<SidebarMenuViewModel>();

        public Tuple<int, int, int> LinkCounter { get; set; }

        public int Order { get; set; } = 999;
    }
}