using System;

using Naitzel.Intranet.Domain.AdminLte.Enums;

namespace Naitzel.Intranet.Domain.AdminLte.Entities
{
    public class Audit
    {
        public int Id { get; set; }

        public AuditType AuditType { get; set; }

        public string TableName { get; set; }

        public string KeyValue { get; set; }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }
    }
}