using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PaymentGateway.Data.Repository.Interface
{
    public interface IDataRepository<TEntity>
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetByCondition(Expression<Func<TEntity, bool>> expression);
    }
}
