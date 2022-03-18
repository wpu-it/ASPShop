using Domain.Entities;
using Services.Abstractions.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.Services
{
    public interface IProductsService : IService<int, ProductDTO>
    {
        Task AddToWishList(ProductDTO product, User user);
        Task RemoveFromWishList(ProductDTO product, User user);
    }
}
