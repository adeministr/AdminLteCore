using Naitzel.Intranet.Domain.AdminLte.Validation;

namespace Naitzel.Intranet.Domain.AdminLte.Interfaces.Validation
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Validate(TEntity entity);

        ValidationResult ValidateOnCreate(TEntity entity);

        ValidationResult ValidateOnUpdate(TEntity entity);
    }
}