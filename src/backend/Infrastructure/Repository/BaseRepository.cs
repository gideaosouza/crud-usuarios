using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Repository.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository{

    public class BaseRepository<TEntity> : IAsyncRepository<TEntity> where TEntity : BaseEntity
    {       
        private protected readonly ApplicationDbContext _efContext;

        public BaseRepository(ApplicationDbContext efContext)
        {
            _efContext = efContext;
        }

        public virtual async Task<TEntity> Insert(TEntity obj)
        {
            await _efContext.Set<TEntity>().AddAsync(obj).ConfigureAwait(false);
            await _efContext.SaveChangesAsync().ConfigureAwait(false); 
            return obj;
        }

        public virtual async Task Update(TEntity obj)
        {
            _efContext.Entry(obj).State = EntityState.Modified;
            await _efContext.SaveChangesAsync().ConfigureAwait(false); 
        }

        public virtual async Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await  _efContext.Set<TEntity>().Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll() =>
            await _efContext.Set<TEntity>().Where(c => c.Habilitado).ToListAsync().ConfigureAwait(false);
        
        public virtual async Task<TEntity> Find(int id)
        {
            return await _efContext.Set<TEntity>().FirstOrDefaultAsync(c => c.Id == id).ConfigureAwait(false);
        }        
    }
}