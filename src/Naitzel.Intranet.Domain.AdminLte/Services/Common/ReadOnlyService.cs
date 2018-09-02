using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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

        public virtual TEntity Get(int id)
        {
            return _readOnlyRepository.Get(id);
        }

        public virtual IEnumerable<TEntity> All()
        {
            return _readOnlyRepository.All();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _readOnlyRepository.Find(predicate);
        }
    }
}