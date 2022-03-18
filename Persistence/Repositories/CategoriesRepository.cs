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
    public class CategoriesRepository : BaseRepository<int, Category>
    {
        public CategoriesRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<Category> Get(int id, CancellationToken cancellationToken = default)
        {
            return await Table.Include(cat => cat.Products).Include(cat => cat.CategoryPhoto).Include(cat => cat.SubCategories).FirstOrDefaultAsync(cat => cat.Id == id);
        }

        public override async Task<List<Category>> GetAll(CancellationToken cancellationToken = default)
        {
            return await Table.Include(cat => cat.Products).Include(cat => cat.CategoryPhoto).Include(cat => cat.SubCategories).ToListAsync();
        }

        public override async Task<List<Category>> GetAll(Func<Category, bool> predicate, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(Table.Include(cat => cat.Products).Include(cat => cat.CategoryPhoto).Include(cat => cat.SubCategories).Where(predicate).ToList());
        }

        public override async Task Update(Category entity)
        {
            var srchEntity = await Get(entity.Id);
            srchEntity.Name = entity.Name;
            Table.Update(srchEntity);
            await db.SaveChangesAsync();
        }
    }
}
