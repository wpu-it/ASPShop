using Domain.Entities;
using Exam.Models;
using Exam.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Persistence.EF;
using Services.Abstractions.DTO;
using Services.Abstractions.Services;
using Services.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceManager _serviceManager;
        Random rnd = new Random();

        public HomeController(ILogger<HomeController> logger, IServiceManager manager)
        {
            _logger = logger;
            _serviceManager = manager;
        }

        public async Task<IActionResult> Index()
        {
            var categories = await _serviceManager.CategoriesService.GetAll();
            var subCategories = await _serviceManager.SubCategoriesService.GetAll();
            var allProducts = await _serviceManager.ProductsService.GetAll();
            var products = new List<ProductDTO>();
            for(int i = 0; i < 5; i++)
            {
                products.Add(allProducts[rnd.Next(0, 65)]);   
            }
            return View(new HomeIndexViewModel { Categories = categories, SubCategories = subCategories, Products = products });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
