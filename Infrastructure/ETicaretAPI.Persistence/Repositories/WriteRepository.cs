using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity>
        where TEntity : BaseEntity, new()
    {

        private readonly ETicaretAPIDbContext _context;

        public WriteRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<bool> AddAsync(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = await Table.AddAsync(entity);
            entityEntry.State = EntityState.Added;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddRangeAsync(List<TEntity> entities)
        {
            await Table.AddRangeAsync(entities);
           await _context.SaveChangesAsync();
            return true;
        }

        public bool Remove(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = Table.Remove(entity);
            entityEntry.State = EntityState.Deleted;
            _context.SaveChanges();
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            TEntity model = await Table.FirstOrDefaultAsync(e => e.Id == id);
            return Remove(model);
        }

        public bool RemoveRange(List<TEntity> entities)
        {
            Table.RemoveRange(entities);
            _context.SaveChanges();
            return true;
        }

        public bool Update(TEntity entity)
        {
            EntityEntry entityEntry = Table.Update(entity);
            entityEntry.State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }


    }
}
