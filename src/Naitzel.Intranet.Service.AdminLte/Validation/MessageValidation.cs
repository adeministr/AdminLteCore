using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Validation;
using Naitzel.Intranet.Domain.AdminLte.Validation;
using Naitzel.Intranet.Service.AdminLte.Validation.Common;
using Naitzel.Intranet.Service.AdminLte.Validation.Validator;

namespace Naitzel.Intranet.Service.AdminLte.Validation
{
    public class MessageValidation : AbstractValidation<Message, MessageValidator>, IMessageValidation
    {
        public MessageValidation() : base(new MessageValidator()) { }
    }
}