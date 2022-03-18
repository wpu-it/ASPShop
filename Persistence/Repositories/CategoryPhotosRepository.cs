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
    public class CategoryPhotosRepository : BaseRepository<int, CategoryPhoto>
    {
        public CategoryPhotosRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<CategoryPhoto> Get(int id, CancellationToken cancellationToken = default)
        {
            return await Table.Include(ph => ph.Category).FirstOrDefaultAsync(ph => ph.Id == id);
        }

        public override async Task<List<CategoryPhoto>> GetAll(CancellationToken cancellationToken = default)
        {
            return await Table.Include(ph => ph.Category).ToListAsync();
        }

        public override async Task<List<CategoryPhoto>> GetAll(Func<CategoryPhoto, bool> predicate, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(Table.Include(ph => ph.Category).Where(predicate).ToList());
        }

        public override async Task Update(CategoryPhoto entity)
        {
            var srchEntity = await Get(entity.Id);
            srchEntity.Path = entity.Path;
            Table.Update(srchEntity);
            await db.SaveChangesAsync();
        }
    }
}
