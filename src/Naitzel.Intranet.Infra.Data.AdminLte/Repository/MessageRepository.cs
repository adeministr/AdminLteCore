using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository.ReadOnly;
using Naitzel.Intranet.Infra.Data.AdminLte.Repository.Common;

namespace Naitzel.Intranet.Infra.Data.AdminLte.Repository
{
    public class MessageRepository : Repository<Message>, IMessageRepository, IMessageReadOnlyRepository
    {
        public MessageRepository(AdminLteContext dbContext) : base(dbContext) { }

        public override Task<IEnumerable<Message>> AllAsync(CancellationToken token = default(CancellationToken), bool @readonly = false)
        {
            return Task.FromResult(Context.Messages.AsEnumerable());
        }
    }
}