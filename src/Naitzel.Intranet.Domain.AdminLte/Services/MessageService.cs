using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository.ReadOnly;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service;
using Naitzel.Intranet.Domain.AdminLte.Services.Common;

namespace Naitzel.Intranet.Domain.AdminLte.Services
{
    public class MessageService : Service<Message>, IMessageService
    {
        public MessageService(
                IMessageRepository repository,
                IMessageReadOnlyRepository readOnlyRepository):
            base(repository, readOnlyRepository) { }
    }
}