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
    public class ProductPhotosRepository : BaseRepository<int, ProductPhoto>
    {
        public ProductPhotosRepository(ApplicationContext context) : base(context)
        {
        }

        public override async Task<ProductPhoto> Get(int id, CancellationToken cancellationToken = default)
        {
            return await Table.Include(ph => ph.Product).FirstOrDefaultAsync(ph => ph.Id == id);
        }
        public override async Task<List<ProductPhoto>> GetAll(CancellationToken cancellationToken = default)
        {
            return await Table.Include(ph => ph.Product).ToListAsync();
        }
        public override async Task<List<ProductPhoto>> GetAll(Func<ProductPhoto, bool> predicate, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(Table.Include(ph => ph.Product).Where(predicate).ToList());
        }

        public override async Task Update(ProductPhoto entity)
        {
            var srchEntity = await Get(entity.Id);
            srchEntity.Path = entity.Path;
            srchEntity.ProductId = entity.ProductId;
            Table.Update(srchEntity);
            await db.SaveChangesAsync();
        }
    }
}
