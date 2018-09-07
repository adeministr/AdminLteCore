using FluentValidation;

using Naitzel.Intranet.Domain.AdminLte.Entities;

namespace Naitzel.Intranet.Service.AdminLte.Validation.Validator
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.UserId).NotNull().NotEmpty();
            RuleFor(x => x.Icon).NotNull().NotEmpty().Length(3, 30);
            RuleFor(x => x.ShortDesc).NotNull().NotEmpty().Length(10, 255);
            RuleFor(x => x.Type).NotNull().NotEmpty().IsInEnum();
            RuleFor(x => x.Status).NotNull().NotEmpty().IsInEnum();
            RuleFor(x => x.Body).NotNull().NotEmpty();
            RuleFor(x => x.Percentage).NotEmpty().LessThan(100);
        }
    }
}