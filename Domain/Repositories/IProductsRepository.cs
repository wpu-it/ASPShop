using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProductsRepository : IRepositoryAsync<int, Product>
    {
        Task UpdateWishList(Product entity);
        Task RemoveFromWishList(Product entity, string userId);
    }
}
