using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Naitzel.Intranet.Domain.AdminLte.Enums;

namespace Naitzel.Intranet.Domain.AdminLte.Entities
{
    public class Message
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public string Icon { get; set; }

        public string URLPath { get; set; }

        public string ShortDesc { get; set; }

        public string Body { get; set; }

        public DateTime Date { get; set; }

        public int Percentage { get; set; }

        public MessageType Type { get; set; }

        public MessageStatusType Status { get; set; }
    }
}