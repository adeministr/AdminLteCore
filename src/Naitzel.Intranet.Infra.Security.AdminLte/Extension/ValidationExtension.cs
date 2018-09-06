using System.Linq;
using CValidation = Naitzel.Intranet.Domain.AdminLte.Validation.ValidationResult;
using CValidationFailure = Naitzel.Intranet.Domain.AdminLte.Validation.ValidationFailure;
using FValidation = FluentValidation.Results.ValidationResult;
using FValidationFailure = FluentValidation.Results.ValidationFailure;

namespace Naitzel.Intranet.Infra.Security.AdminLte.Extension
{
    public static class ValidationExtension
    {
        public static CValidation ToValidation(this FValidation obj)
        {
            return new CValidation(obj.Errors.Select(Mapper).ToList());
        }

        private static CValidationFailure Mapper(FValidationFailure error)
        {
            return new CValidationFailure(error.PropertyName, error.ErrorMessage, error.AttemptedValue);
        }
    }
}