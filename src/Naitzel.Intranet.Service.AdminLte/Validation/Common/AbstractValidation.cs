using System.Linq;

using FluentValidation;

using Naitzel.Intranet.Domain.AdminLte.Interfaces.Validation;
using Naitzel.Intranet.Domain.AdminLte.Validation;
using Naitzel.Intranet.Service.AdminLte.Extension;

namespace Naitzel.Intranet.Service.AdminLte.Validation.Common
{
    public abstract class AbstractValidation<TEntity, TValidator> : IValidation<TEntity>
        where TValidator : AbstractValidator<TEntity>
        {
            protected readonly TValidator Validator;

            public AbstractValidation(TValidator validator) => Validator = validator;

            public virtual ValidationResult ValidateOnCreate(TEntity entity)
            {
                return Validate(entity);
            }

            public virtual ValidationResult ValidateOnUpdate(TEntity entity)
            {
                return Validate(entity);
            }

            public virtual ValidationResult Validate(TEntity entity)
            {
                return Validator.Validate(entity).ToValidation();
            }
        }
}