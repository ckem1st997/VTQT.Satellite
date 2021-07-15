using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace VTQT.Satellite.Service.SatelliteService.GenericRepository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int records = 0);


        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int records = 0);

        TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null);
        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null);


        int Insert(TEntity entity);

        int Delete(Expression<Func<TEntity, bool>> filter = null);

        int Update(TEntity entity);

        Task<int> InsertAsync(TEntity entity);

        Task<int> DeleteAsync(Expression<Func<TEntity, bool>> filter = null);

        Task<int> UpdateAsync(TEntity entity);


    }
}
