using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
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

        public IQueryable<TEntity> FindAll(Expression<Func<TEntity, bool>> method = null, bool tracking = true)
        {
            var query = method == null ? Table : Table.Where(method);
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
        public IQueryable<TEntity> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
               query = query.AsNoTracking();
            }
            return query;
        }

        public async Task<TEntity> GetByIdAsync(int id, bool tracking = true)
        {
            //return await Table.FirstOrDefaultAsync(e => e.Id == id);
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(x=>x.Id==id); // marker pattern üzerinden erişiyoruz
        }


        public async Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(method);

        }
    }
}
