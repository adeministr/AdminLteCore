using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Audits;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Audits.Common;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository.ReadOnly;
using Naitzel.Intranet.Infra.Data.AdminLte.Repository.Common;

namespace Naitzel.Intranet.Infra.Data.AdminLte.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository, IMessageReadOnlyRepository
    {
        public MessageRepository(IAuditService<Message> audit, AdminLteContext dbContext) : base(audit, dbContext) { }

        public override Task<IEnumerable<Message>> AllAsync(CancellationToken cancellationToken = default(CancellationToken), bool @readonly = false)
        {
            return Task.FromResult(Context.Messages.AsEnumerable());
        }
    }
}