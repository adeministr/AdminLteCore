namespace Naitzel.Intranet.Domain.AdminLte.Interfaces.Validation
{
    public interface IValidationRule<in TEntity>
    {
        string ErrorMessage { get; }

        bool Valid(TEntity entity);
    }
}