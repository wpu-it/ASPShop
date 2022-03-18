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
    public class BlackIpsRepository : BaseRepository<int, IPAdress>
    {
        public BlackIpsRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<IPAdress> Get(int id, CancellationToken cancellationToken = default)
        {
            return await Table.FirstOrDefaultAsync(ip => ip.Id == id);
        }

        public override async Task Update(IPAdress entity)
        {
            var srchEntity = await Get(entity.Id);
            srchEntity.Name = entity.Name;
            Table.Update(srchEntity);
            await db.SaveChangesAsync();
        }
    }
}
