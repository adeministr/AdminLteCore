using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

using Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository.Common;
using Naitzel.Intranet.Domain.AdminLte.Interfaces.Service.Common;

namespace Naitzel.Intranet.Domain.AdminLte.Services.Common
{
    public class ReadOnlyService<TEntity> : IReadOnlyService<TEntity> where TEntity : class
    {
        private readonly IReadOnlyRepository<TEntity> _readOnlyRepository;

        public ReadOnlyService(IReadOnlyRepository<TEntity> readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
        }

        protected IReadOnlyRepository<TEntity> ReadOnlyRepository
        {
            get { return _readOnlyRepository; }
        }

        public virtual Task<TEntity> GetAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _readOnlyRepository.GetAsync(id, cancellationToken);
        }

        public virtual Task<IEnumerable<TEntity>> AllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return _readOnlyRepository.AllAsync(cancellationToken);
        }

        public virtual Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default(CancellationToken))
        {
            return _readOnlyRepository.FindAsync(predicate, cancellationToken);
        }
    }
}