using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public abstract class BaseRepository<TKey, TValue> : IRepositoryAsync<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
        protected ApplicationContext db;
        protected DbSet<TValue> Table => db.Set<TValue>();
        public BaseRepository(ApplicationContext context)
        {
            db = context;
        }

        public async Task Create(TValue entity)
        {
            Table.Add(entity);
            await db.SaveChangesAsync();
        }

        public abstract Task<TValue> Get(TKey id, CancellationToken cancellationToken = default);

        public virtual async Task<List<TValue>> GetAll(CancellationToken cancellationToken = default)
        {
            return await Table.ToListAsync();
        }

        public virtual async Task<List<TValue>> GetAll(Func<TValue, bool> predicate, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(Table.Where(predicate).ToList());
        }

        public async Task Remove(TKey id)
        {
            var entity = await Get(id);
            Table.Remove(entity);
            await db.SaveChangesAsync();
        }

        public abstract Task Update(TValue entity);
    }
}
