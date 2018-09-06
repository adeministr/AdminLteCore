namespace Naitzel.Intranet.Domain.AdminLte.Validation
{
    public class ValidationFailure
    {
        public string ErrorMessage { get; set; }

        public string PropertyName { get; set; }

        public object AttemptedValue { get; set; }

        public ValidationFailure(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public ValidationFailure(string propertyName, string errorMessage)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }

        public ValidationFailure(string propertyName, string errorMessage, object attemptedValue)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
            AttemptedValue = attemptedValue;
        }
    }
}