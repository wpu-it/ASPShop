using Exam.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Services
{
    public interface ICartSessionService
    {
        void AddProductToCart(HttpContext context, ProductBasketViewModel product);
        void RemoveProductFromCart(HttpContext context, ProductBasketViewModel product);
        void ClearCart(HttpContext context);
        List<ProductBasketViewModel> GetCartProducts(HttpContext context);
    }
}
