using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Venta.Domain.Core
{
    public interface IRepositoryBase <TEntity> where TEntity : class
    {
        Task<List<TEntity>> Get();

        Task Save(TEntity entity);

        Task Delete(TEntity entity);

        Task Update(TEntity entity);

        Task<bool> Exists(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> GetByID(int entityID);
    }
}
