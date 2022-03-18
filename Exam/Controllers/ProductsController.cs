using Domain.Entities;
using Exam.Models;
using Exam.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Services.Abstractions.DTO;
using Services.Abstractions.Services;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Controllers
{
    public class ProductsController : Controller
    {
        static string _query = "";
        IServiceManager _serviceManager;
        private readonly ICartSessionService _cartSessionService;
        UserManager<User> userManager;
        public ProductsController(UserManager<User> userManager, IServiceManager serviceManager, ICartSessionService cartSessionService)
        {
            _serviceManager = serviceManager;
            _cartSessionService = cartSessionService;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Product(int id)
        {
            var product = await _serviceManager.ProductsService.Get(id);
            return View(new ShowProductViewModel { Product = product});
        }

        public async Task<IActionResult> SearchResult()
        {
            _query = _query.ToLower();
            var prods = await _serviceManager.ProductsService.GetAll();
            var res = new List<ProductDTO>();
            foreach (var prod in prods)
            {
                string prodName = prod.Name.ToLower();
                if (prodName.Contains(_query)) res.Add(prod);
            }
            return View(new SearchResultViewModel { Products = res });
        }
        [HttpPost]
        public void SearchResult(string query)
        {
            _query = query;
        }

        public async Task<IActionResult> AddToCart(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            ProductDTO product = await _serviceManager.ProductsService.Get((int)id);

            if (product is null)
            {
                return NotFound("Product wasn`t found...");
            }

            _cartSessionService.AddProductToCart(HttpContext, new ProductBasketViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image = product.ProductPhotos[0].Path,
                Quantity = 1
            });
            StringValues referer;
            HttpContext.Request.Headers.TryGetValue("referer", out referer);
            return Redirect(referer.First());
        }

        public async Task<IActionResult> RemoveFromCart(int? id)
        {
            if (id is null)
            {
                return BadRequest();
            }

            ProductDTO product = await _serviceManager.ProductsService.Get((int)id);

            if (product is null)
            {
                return NotFound("Product wasn`t found...");
            }

            _cartSessionService.RemoveProductFromCart(HttpContext, new ProductBasketViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image = product.ProductPhotos[0].Path
            });
            StringValues referer;
            HttpContext.Request.Headers.TryGetValue("referer", out referer);
            return Redirect(referer.First());
        }

        [HttpPost]
        public IActionResult ChangeQuantity(int? id, int? quantity)
        {
            if (id is null || quantity is null)
            {
                return BadRequest("Incorrect data!!!");
            }

            var products = _cartSessionService.GetCartProducts(HttpContext);
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product is null)
            {
                return NotFound("Product wasn`t found...");
            }
            var addProduct = new ProductBasketViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Image = product.Image,
                Quantity = (int)quantity - product.Quantity
            };
            _cartSessionService.AddProductToCart(HttpContext, addProduct);
            StringValues referer;
            HttpContext.Request.Headers.TryGetValue("referer", out referer);
            return Redirect(referer.First());
        }

        [Authorize]
        public async Task AddToWishList(int? id)
        {
            var product = await _serviceManager.ProductsService.Get((int)id);
            var user = userManager.Users.First();
            await _serviceManager.ProductsService.AddToWishList(product, user);
        }

        [Authorize]
        public async Task RemoveFromWishList(int? id)
        {
            var product = await _serviceManager.ProductsService.Get((int)id);
            var user = userManager.Users.First();
            await _serviceManager.ProductsService.RemoveFromWishList(product, user);
        }
    }
}
