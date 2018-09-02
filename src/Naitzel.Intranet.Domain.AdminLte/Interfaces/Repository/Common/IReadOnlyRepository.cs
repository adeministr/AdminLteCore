using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Naitzel.Intranet.Domain.AdminLte.Interfaces.Repository.Common
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        IEnumerable<TEntity> All();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}