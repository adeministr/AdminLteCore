using System.Collections.Generic;
using System.Linq;

namespace Naitzel.Intranet.Domain.AdminLte.Validation
{
    public class ValidationResult
    {
        private readonly IList<ValidationFailure> _erros = new List<ValidationFailure>();

        private string Message { get; set; }

        public bool IsValid { get { return !_erros.Any(); } }

        public IList<ValidationFailure> Errors { get { return _erros; } }

        public ValidationResult() { }

        public ValidationResult(string errorMessage) => Add(errorMessage);

        public ValidationResult(IList<ValidationFailure> errors) => _erros = errors;

        public ValidationResult Add(string errorMessage)
        {
            _erros.Add(new ValidationFailure(errorMessage));
            return this;
        }

        public ValidationResult Add(ValidationFailure error)
        {
            _erros.Add(error);
            return this;
        }

        public ValidationResult Add(params ValidationResult[] validationResults)
        {
            if (validationResults == null) return this;

            foreach (var result in validationResults.Where(r => r != null))
                _erros.ToList().AddRange(result.Errors);

            return this;
        }

        public ValidationResult Remove(ValidationFailure error)
        {
            if (_erros.Contains(error))
                _erros.Remove(error);
            return this;
        }
    }
}