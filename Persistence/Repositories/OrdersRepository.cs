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
    public class OrdersRepository : IOrdersRepository
    {
        ApplicationContext db;
        DbSet<Order> Table => db.Set<Order>();
        public OrdersRepository(ApplicationContext context)
        {
            db = context;
        }

        public async Task<Order> Get(int id, CancellationToken cancellationToken = default)
        {
            return await Table.Include(ord => ord.Products).Include(ord => ord.User).FirstOrDefaultAsync(ord => ord.Id == id);
        }

        public async Task<List<Order>> GetAll(CancellationToken cancellationToken = default)
        {
            return await Table.Include(ord => ord.Products).Include(ord => ord.User).ToListAsync();
        }

        public async Task<List<Order>> GetAll(Func<Order, bool> predicate, CancellationToken cancellationToken = default)
        {
            return await Task.FromResult(Table.Include(ord => ord.Products).Include(ord => ord.User).Where(predicate).ToList());
        }

        public async Task Update(Order entity)
        {
            var srchEntity = await Get(entity.Id);
            srchEntity.Number = entity.Number;
            srchEntity.OverallPrice = entity.OverallPrice;
            srchEntity.PostNumber = entity.PostNumber;
            srchEntity.PhoneNumber = entity.PhoneNumber;
            srchEntity.UserId = entity.UserId;
            Table.Update(srchEntity);
            await db.SaveChangesAsync();
        }

        public async Task UpdateProducts(Order order)
        {
            Order srchEntity = await db.Orders.Include(or => or.Products).FirstOrDefaultAsync(or => or.Id == order.Id);
            srchEntity.Products.Clear();
            foreach (var item in order.Products)
            {
                var product = await db.Products.FirstOrDefaultAsync(prod => prod.Id == item.Id);
                srchEntity.Products.Add(product);
                await db.SaveChangesAsync();
            }
        }

        public async Task Create(Order entity)
        {
            Table.Add(entity);
            await db.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var entity = await Get(id);
            Table.Remove(entity);
            await db.SaveChangesAsync();
        }
    }
}
