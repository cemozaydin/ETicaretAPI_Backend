using ETicaretAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<TEntity> : IRepository<TEntity> 
        where TEntity : BaseEntity, new()
    {
        Task<bool> AddAsync(TEntity entity);
        Task<bool> AddRangeAsync(List<TEntity> entities);
        bool Remove(TEntity entity);
        Task<bool> RemoveAsync(int id);
        bool RemoveRange(List<TEntity> entities);
        bool Update(TEntity entity);
        
    }   
}


// Not 1 :Task'e bool verilmesinin sebebi; Ekleyebildiysek veya TEntity'yi silebildiysek bize true veya false dönmesini sağlamak.