using Naitzel.Intranet.Domain.AdminLte.Interfaces.Specification;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Validation;

namespace Naitzel.Intranet.Domain.AdminLte.Validation
{
    public class ValidationRule<TEntity> : IValidationRule<TEntity>
    {
        private readonly ISpecification<TEntity> _specificationRule;

        public ValidationRule(ISpecification<TEntity> specificationRule, string errorMessage)
        {
            _specificationRule = specificationRule;
            ErrorMessage = errorMessage;
        }

        public string ErrorMessage { get; private set; }
        public bool Valid(TEntity entity)
        {
            return _specificationRule.IsSatisfiedBy(entity);
        }
    }
}