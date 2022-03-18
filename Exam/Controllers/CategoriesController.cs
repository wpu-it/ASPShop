using Exam.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions.DTO;
using Services.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Services.Services;

namespace Exam.Controllers
{
    public class CategoriesController : Controller
    {
        static List<string> _producers;
        static int _minPrice;
        static int _maxPrice;
        static List<ProductDTO> _prods;
        readonly IServiceManager serviceManager;
        public CategoriesController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Category(int id)
        {
            var cat = await serviceManager.CategoriesService.Get(id);
            return View(new CategoryViewModel { Category = cat });
        }

        public async Task<IActionResult> SubCategory(int id, int page)
        {
            //select prods to page if(page==1){} else{} + formula
            var subCat = await serviceManager.SubCategoriesService.Get(id);
            var prods = await serviceManager.ProductsService.GetAll();
            var producers = new List<ProducerDTO>();
            var res = new List<ProductDTO>();
            var prod_res = new List<ProductDTO>();
            await Task.Run(() =>
            {
                foreach (var prod in prods)
                {
                    if (prod.SubCategoryId == id)
                    {
                        res.Add(prod);
                    }
                }
                if(page == 1)
                {
                    for (int i = 0; i < 4; i++) prod_res.Add(res[i]);
                }
                else
                {
                    for(int i = page * 4 - 4; i < page * 4; i++)
                    {
                        if (i < res.Count) prod_res.Add(res[i]);
                    }
                }
                _prods = res;
                foreach (var prod in res)
                {
                    if (producers.Find(p => p.Id == prod.ProducerId) == null) producers.Add(prod.Producer);
                }
            });
            return View(new SubCategoryViewModel { SubCategory = subCat, Products = prod_res, Producers = producers, 
                OverallProductsCount = res.Count, Page = page });
        }

        public IActionResult SortProducts()
        {
            var sortProducts = new List<ProductDTO>();
            foreach (var item in _prods)
            {
                if(item.Price > _minPrice && item.Price < _maxPrice)
                {
                    foreach (var producer in _producers)
                    {
                        if (item.Producer.Name == producer)
                        {
                            sortProducts.Add(item);
                        }
                    }
                }
            }
            return View(new SortProductsViewModel { Products = sortProducts });
        }

        [HttpPost]
        public void SortProducts(List<string> producers, int minPrice, int maxPrice)
        {
            _producers = producers;
            _minPrice = minPrice;
            _maxPrice = maxPrice;
        }
    }
}
