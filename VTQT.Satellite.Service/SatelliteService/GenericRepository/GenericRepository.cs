
using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VTQT.Satellite.Service.SatelliteService.DataContext;

namespace VTQT.Satellite.Service.SatelliteService.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly AppDataConnection _context;

        public GenericRepository(AppDataConnection context)
        {
            _context = context;
        }
        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int records = 0)
        {
            IQueryable<TEntity> query = _context.GetTable<TEntity>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (records > 0 && orderBy != null)
            {
                query = orderBy(query).Take(records);
            }
            else if (orderBy != null && records == 0)
            {
                query = orderBy(query);
            }
            else if (orderBy == null && records > 0)
            {
                query = query.Take(records);
            }

            return query.ToList();
        }
        //aync

        public async Task<IEnumerable<TEntity>> GetAsync(
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, int records = 0)
        {
            IQueryable<TEntity> query = _context.GetTable<TEntity>();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (records > 0 && orderBy != null)
            {
                query = orderBy(query).Take(records);
            }
            else if (orderBy != null && records == 0)
            {
                query = orderBy(query);
            }
            else if (orderBy == null && records > 0)
            {
                query = query.Take(records);
            }

            return await query.ToListAsync();
        }
        public TEntity GetFirst(Expression<Func<TEntity, bool>> filter = null)
        {
            return _context.GetTable<TEntity>().FirstOrDefault(filter);
        }
        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _context.GetTable<TEntity>().FirstOrDefaultAsync(filter);
        }


        public int Insert(TEntity entity)
        {
            return _context.Insert(entity);
        }

        public int Delete(Expression<Func<TEntity, bool>> filter = null)
        {
            return _context.GetTable<TEntity>().Where(filter).Delete();
        }

        public int Update(TEntity entityToUpdate)
        {
            return _context.Update(entityToUpdate);
        }



        public async Task<int> InsertAsync(TEntity entity)
        {
            return await _context.InsertAsync(entity);
        }

        public async Task<int> DeleteAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return await _context.GetTable<TEntity>().Where(filter).DeleteAsync();
        }

        public async Task<int> UpdateAsync(TEntity entityToUpdate)
        {
            return await _context.UpdateAsync(entityToUpdate);
        }

    }
}

