using System;
using System.Collections.Generic;

namespace PaymentGateway.Data.Repository.Interface
{
    public interface IDataRepository<TEntity>
    {
        TEntity Get(Guid id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
    }
}
