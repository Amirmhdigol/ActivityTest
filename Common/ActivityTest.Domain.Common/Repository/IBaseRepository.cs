using ActivityTest.Domain.Common.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActivityTest.Domain.Common.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T?> GetTracking(long id);
        Task<T?> GetAsync(long id);
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        Task<int> Save();
    }
}