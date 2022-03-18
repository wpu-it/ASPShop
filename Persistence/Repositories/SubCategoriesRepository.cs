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
    public class SubCategoriesRepository : BaseRepository<int, SubCategory>
    {
        public SubCategoriesRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<SubCategory> Get(int id, CancellationToken cancellationToken = default)
        {
            return await Table.Include(cat => cat.Category).FirstOrDefaultAsync(cat => cat.Id == id);
        }

        public override async Task<List<SubCategory>> GetAll(CancellationToken cancellationToken = default)
        {
            return await Table.Include(cat => cat.Category).ToListAsync();
        }

        public override async Task<List<SubCategory>> GetAll(Func<SubCategory, bool> predicate, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(Table.Include(cat => cat.Category).Where(predicate).ToList());
        }

        public override async Task Update(SubCategory entity)
        {
            var srchEntity = await Get(entity.Id);
            srchEntity.Name = entity.Name;
            srchEntity.CategoryId = entity.CategoryId;
            Table.Update(srchEntity);
            await db.SaveChangesAsync();
        }
    }
}
