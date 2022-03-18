using Domain.Entities;
using Exam.Models;
using Exam.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.DTO;
using Services.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Controllers
{
    public class OrderController : Controller
    {
        static List<ProductBasketViewModel> prods;
        IServiceManager _serviceManager;
        ICartSessionService cartSessionService;
        UserManager<User> userManager;
        Random rnd = new Random();
        public OrderController(UserManager<User> userManager, IServiceManager serviceManager, ICartSessionService cartSessionService)
        {
            this.userManager = userManager;
            _serviceManager = serviceManager;
            this.cartSessionService = cartSessionService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult NewOrder()
        {
            var user = userManager.Users.First();
            decimal ovPrice = 0;
            foreach (var prod in prods)
            {
                ovPrice += (prod.Quantity * prod.Price);
            }
            return View(new NewOrderViewModel { Products = prods, User = user, OverallPrice = ovPrice });
        }

        [Authorize]
        [HttpPost]
        public void NewOrder(List<ProductBasketViewModel> products)
        {
            prods = products;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ConfirmOrder(ConfirmOrderViewModel model)
        {
            var order = new OrderDTO
            {
                Number = rnd.Next(0, 100_000),
                PhoneNumber = model.PhoneNumber,
                Postnumber = model.PostNumber,
                OverallPrice = model.OverallPrice,
                CreatedAt = DateTime.Now,
                UserId = userManager.Users.First().Id
            };
            await _serviceManager.OrdersService.Create(order);

            var orders = await _serviceManager.OrdersService.GetAll();
            foreach (var item in orders)
            {
                if (item.Number == order.Number) order = item;
            }
            var products = await _serviceManager.ProductsService.GetAll();
            var resProds = new List<ProductDTO>();
            foreach (var item in products)
            {
                foreach (var prod in prods)
                {
                    if (item.Id == prod.Id) resProds.Add(item);
                }
            }
            order.Products.AddRange(resProds);
            await _serviceManager.OrdersService.UpdateProducts(order);
            cartSessionService.ClearCart(HttpContext);

            return RedirectToAction("Index", "Home");
        }
    }
}
