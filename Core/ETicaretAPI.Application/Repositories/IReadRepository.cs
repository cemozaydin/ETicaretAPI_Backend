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
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> FindAll(Expression<Func<TEntity,bool>> method=null);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity,bool>> method); //Async çalışacağı için Task olarak tipini belirledik
        Task<TEntity> GetByIdAsync(int id); // Asenkron çalışacaklar
    }
}
