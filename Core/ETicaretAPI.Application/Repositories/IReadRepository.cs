using ETicaretAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> 
        where TEntity : BaseEntity, new()
    {
        IQueryable<TEntity> GetAll(bool tracking = true);
        IQueryable<TEntity> FindAll(Expression<Func<TEntity,bool>> method=null, bool tracking = true);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity,bool>> method, bool tracking = true); //Async çalışacağı için Task olarak tipini belirledik
        Task<TEntity> GetByIdAsync(int id, bool tracking = true); // Asenkron çalışacaklar
    }
}
