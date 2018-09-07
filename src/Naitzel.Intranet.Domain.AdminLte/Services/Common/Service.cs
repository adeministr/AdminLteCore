using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository.Common;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service.Common;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Validation;
using Naitzel.Intranet.Domain.AdminLte.Validation;

namespace Naitzel.Intranet.Domain.AdminLte.Services.Common
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IReadOnlyRepository<TEntity> _readOnlyRepository;
        private readonly IValidation<TEntity> _validation;
        private readonly ValidationResult _validationResult;

        public Service(
            IRepository<TEntity> repository,
            IReadOnlyRepository<TEntity> readOnlyRepository,
            IValidation<TEntity> validation)
        {
            _repository = repository;
            _readOnlyRepository = readOnlyRepository;
            _validation = validation;
            _validationResult = new ValidationResult();
        }

        protected IRepository<TEntity> Repository
        {
            get { return _repository; }
        }

        protected IReadOnlyRepository<TEntity> ReadOnlyRepository
        {
            get { return _readOnlyRepository; }
        }

        protected ValidationResult ValidationResult
        {
            get { return _validationResult; }
        }

        public virtual Task<TEntity> GetAsync(int id, CancellationToken cancellationToken = default(CancellationToken), bool @readonly = false)
        {
            return @readonly ?
                _readOnlyRepository.GetAsync(id, cancellationToken) :
                _repository.GetAsync(id, cancellationToken);
        }

        public virtual Task<IEnumerable<TEntity>> AllAsync(CancellationToken cancellationToken = default(CancellationToken), bool @readonly = false)
        {
            return @readonly ?
                _readOnlyRepository.AllAsync(cancellationToken) :
                _repository.AllAsync(cancellationToken, @readonly);
        }

        public virtual Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken), bool @readonly = false)
        {
            return @readonly ?
                _readOnlyRepository.FindAsync(predicate, cancellationToken) :
                _repository.FindAsync(predicate, cancellationToken, @readonly);
        }

        public virtual Task<ValidationResult> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!ValidationResult.IsValid)
                return Task.FromResult(ValidationResult);

            var iValidation = _validation.ValidateOnCreate(entity);
            if (iValidation != null && !iValidation.IsValid)
                return Task.FromResult(iValidation);

            _repository.AddAsync(entity, cancellationToken);
            return Task.FromResult(_validationResult);
        }

        public virtual Task<ValidationResult> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!ValidationResult.IsValid)
                return Task.FromResult(ValidationResult);

            var iValidation = _validation.ValidateOnUpdate(entity);
            if (iValidation != null && !iValidation.IsValid)
                return Task.FromResult(iValidation);

            _repository.UpdateAsync(entity, cancellationToken);
            return Task.FromResult(_validationResult);
        }

        public virtual Task<ValidationResult> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!ValidationResult.IsValid)
                return Task.FromResult(ValidationResult);

            _repository.DeleteAsync(entity, cancellationToken);
            return Task.FromResult(_validationResult);
        }

    }
}