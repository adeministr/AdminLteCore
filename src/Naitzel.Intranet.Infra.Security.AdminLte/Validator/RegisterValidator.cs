using System;
using System.Threading;
using System.Threading.Tasks;

using FluentValidation;

using Microsoft.AspNetCore.Identity;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Infra.Security.AdminLte.ViewModel;

namespace Naitzel.Intranet.Infra.Security.AdminLte.Validator
{
    public class RegisterValidator : AbstractValidator<RegisterViewModel>
    {
        public RegisterValidator()
        {
            RuleFor(i => i.FirstName).NotNull().NotEmpty();
            RuleFor(i => i.LastName).NotNull().NotEmpty();
            RuleFor(i => i.UserName).NotNull().NotEmpty();
            RuleFor(i => i.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(i => i.Password).NotNull().NotEmpty();
            RuleFor(i => i.ConfirmPassword).NotNull().Equal(x => x.Password);
        }
    }
}