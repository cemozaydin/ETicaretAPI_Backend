using ETicaretAPI.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity, new()
    {
        DbSet<TEntity> Table { get; }
    }
}
