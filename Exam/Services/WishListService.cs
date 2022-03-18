using Domain.Entities;
using Exam.Models;
using Microsoft.AspNetCore.Identity;
using Services.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Services
{
    public class WishListService : IWishListService
    {
        IServiceManager manager;
        string userId;
        public WishListService(IServiceManager manager, UserManager<User> userManager)
        {
            this.manager = manager;
            if(userManager.Users.Count() > 0)
            {
                userId = userManager.Users.First().Id;
            }
        }

        public async Task<List<ProductBasketViewModel>> GetWishList()
        {
            var user = await manager.UsersService.Get(userId);
            var prods = new List<ProductBasketViewModel>();
            if(user != null)
            {
                foreach (var item in user.Products)
                {
                    var prod = await manager.ProductsService.Get(item.Id);
                    prods.Add(new ProductBasketViewModel
                    {
                        Id = prod.Id,
                        Name = prod.Name,
                        Image = prod.ProductPhotos[0].Path,
                        Price = prod.Price
                    });
                }
            }
            return prods;
        }

        public async Task<int> GetWishListCount()
        {
            var user = await manager.UsersService.Get(userId);
            if (user != null) return user.Products.Count;
            else return 0;
        }
    }
}
