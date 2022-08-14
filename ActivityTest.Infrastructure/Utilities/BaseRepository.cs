using ActivityTest.Domain.Common.Bases;
using ActivityTest.Domain.Common.Repository;
using ActivityTest.Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTest.Infrastructure.Utilities
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ActivityContext _context;
        public BaseRepository(ActivityContext context)
        {
            _context = context;
        }

        public virtual async Task<TEntity?> GetAsync(long id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(t => t.Id == (id)); 
        }

        public async Task<TEntity?> GetTracking(long id)
        {
            return await _context.Set<TEntity>().AsTracking().FirstOrDefaultAsync(t => t.Id == (id));
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        void IBaseRepository<TEntity>.Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}