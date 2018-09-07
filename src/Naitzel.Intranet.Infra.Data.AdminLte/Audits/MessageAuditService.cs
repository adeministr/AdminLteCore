using System;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Audits;
using Naitzel.Intranet.Infra.Data.AdminLte.Audits.Common;

namespace Naitzel.Intranet.Infra.Data.AdminLte.Audits
{
    public class MessageAuditService : AuditService<Message>, IMessageAuditService
    {
        public MessageAuditService(AdminLteContext context) : base(context) { }
    }
}