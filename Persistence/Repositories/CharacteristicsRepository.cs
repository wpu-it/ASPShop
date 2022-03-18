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
    public class CharacteristicsRepository : BaseRepository<int, Characteristic>
    {
        public CharacteristicsRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<Characteristic> Get(int id, CancellationToken cancellationToken = default)
        {
            return await Table.Include(ch => ch.Product).FirstOrDefaultAsync(ch => ch.Id == id);
        }

        public override async Task<List<Characteristic>> GetAll(CancellationToken cancellationToken = default)
        {
            return await Table.Include(ch => ch.Product).ToListAsync();
        }

        public override async Task<List<Characteristic>> GetAll(Func<Characteristic, bool> predicate, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(Table.Include(ch => ch.Product).Where(predicate).ToList());
        }

        public override async Task Update(Characteristic entity)
        {
            var srchEntity = await Get(entity.Id);
            srchEntity.Name = entity.Name;
            srchEntity.Value = entity.Value;
            srchEntity.ProductId = entity.ProductId;
            Table.Update(srchEntity);
            await db.SaveChangesAsync();
        }
    }
}
