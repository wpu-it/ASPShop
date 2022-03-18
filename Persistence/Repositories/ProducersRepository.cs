using Domain.Entities;
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
    public class ProducersRepository : BaseRepository<int, Producer>
    {
        public ProducersRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<Producer> Get(int id, CancellationToken cancellationToken = default)
        {
            return await Table.Include(prod => prod.Products).FirstOrDefaultAsync(prod => prod.Id == id);
        }

        public override async Task<List<Producer>> GetAll(CancellationToken cancellationToken = default)
        {
            return await Table.Include(prod => prod.Products).ToListAsync();
        }

        public override async Task<List<Producer>> GetAll(Func<Producer, bool> predicate, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(Table.Include(prod => prod.Products).Where(predicate).ToList());
        }

        public override async Task Update(Producer entity)
        {
            var srchEntity = await Get(entity.Id);
            srchEntity.Name = entity.Name;
            Table.Update(srchEntity);
            await db.SaveChangesAsync();
        }
    }
}
