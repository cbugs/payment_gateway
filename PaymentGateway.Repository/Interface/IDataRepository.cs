using System;
using System.Linq;
using System.Linq.Expressions;

namespace PaymentGateway.Data.Repository.Interface
{
    public interface IDataRepository<TEntity>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> expression);
    }
}
