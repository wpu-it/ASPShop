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
    public class ProductsRepository : IProductsRepository
    {
        ApplicationContext db;
        DbSet<Product> Table => db.Set<Product>();
        public ProductsRepository(ApplicationContext context)
        {
            db = context;
        }

        public Task Create(Product entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Get(int id, CancellationToken cancellationToken = default)
        {
            return await Table.Include(prod => prod.Category).Include(prod => prod.Characteristics).Include(prod => prod.ProductPhotos)
                .Include(prod => prod.Producer).Include(prod => prod.Users).Include(prod => prod.SubCategory).FirstOrDefaultAsync(prod => prod.Id == id);
        }

        public async Task<List<Product>> GetAll(CancellationToken cancellationToken = default)
        {
            return await Table.Include(prod => prod.Category).Include(prod => prod.Characteristics).Include(prod => prod.ProductPhotos)
                .Include(prod => prod.Producer).Include(prod => prod.Users).Include(prod => prod.SubCategory).ToListAsync();
        }

        public async Task<List<Product>> GetAll(Func<Product, bool> predicate, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(Table.Include(prod => prod.Category).Include(prod => prod.Characteristics).Include(prod => prod.ProductPhotos)
                .Include(prod => prod.Producer).Include(prod => prod.Users).Include(prod => prod.SubCategory).Where(predicate).ToList());
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(Product entity)
        {
            var srchEntity = await Get(entity.Id);
            srchEntity.Users.Clear();
            srchEntity.CategoryId = entity.CategoryId;
            srchEntity.Name = entity.Name;
            srchEntity.Price = entity.Price;
            srchEntity.ProducerId = entity.ProducerId;
            Table.Update(srchEntity);
            await db.SaveChangesAsync();
        }

        public async Task UpdateWishList(Product entity)
        {
            Product srchEntity = await Table.Include(prod => prod.Users).FirstOrDefaultAsync(prod => prod.Id == entity.Id);
            srchEntity.Users.Clear();
            foreach (var item in entity.Users)
            {
                var user = await db.Users.FirstOrDefaultAsync(us => us.Id == item.Id);
                srchEntity.Users.Add(user);
                await db.SaveChangesAsync();
            }
        }

        public async Task RemoveFromWishList(Product entity, string userId)
        {
            Product srchEntity = await Table.Include(cl => cl.Users).FirstOrDefaultAsync(cl => cl.Id == entity.Id);
            foreach (var item in srchEntity.Users)
            {
                if (item.Id == userId)
                {
                    var user = await db.Users.FirstOrDefaultAsync(us => us.Id == userId);
                    srchEntity.Users.Remove(user);
                    await db.SaveChangesAsync();
                }
            }
        }
    }
}
