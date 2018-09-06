using AutoMapper;

using FluentValidation;

using Naitzel.Intranet.Domain.AdminLte.Entities;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Validation;
using Naitzel.Intranet.Domain.AdminLte.Validation;
using Naitzel.Intranet.Infra.Security.AdminLte.Extension;

namespace Naitzel.Intranet.Infra.Security.AdminLte.Validator
{
    public class UserValidation : IUserValidation
    {
        private readonly UserValidator _validator;

        private readonly IMapper _mapper;

        private class UserValidator : AbstractValidator<User>
        {
            public UserValidator()
            {
                RuleFor(i => i.FirstName).NotNull().NotEmpty();
                RuleFor(i => i.LastName).NotNull().NotEmpty();
                RuleFor(i => i.UserName).NotNull().NotEmpty();
                RuleFor(i => i.Email).NotNull().NotEmpty().EmailAddress();
                RuleFor(i => i.Password).NotNull().NotEmpty();
            }
        }

        public UserValidation(IMapper mapper)
        {
            _validator = new UserValidator();
            _mapper = mapper;
        }

        public ValidationResult Validate(User entity)
        {
            return _mapper.Map<ValidationResult>(_validator.Validate(entity));
        }

        public ValidationResult ValidateOnCreate(User entity)
        {
            return _mapper.Map<ValidationResult>(_validator.Validate(entity));
        }

        public ValidationResult ValidateOnUpdate(User entity)
        {
            return _mapper.Map<ValidationResult>(_validator.Validate(entity));
        }
    }
}