using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<TEntity> : IReadRepository<TEntity> 
        where TEntity : BaseEntity, new()
    {
        private readonly ETicaretAPIDbContext _context;

        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> method = null)
        => method == null ? Table : Table.Where(method);

        public IQueryable<TEntity> GetAll()
        {
            return Table;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Table.FirstOrDefaultAsync(e=>e.Id== id);             
        }

        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method)
        => await Table.FirstOrDefaultAsync(method);
    }
}
