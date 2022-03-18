using Exam.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Services
{
    
    public class CartSessionService : ICartSessionService
    {
        public void AddProductToCart(HttpContext context, ProductBasketViewModel product)
        {
            if (context.Session.GetString("cart") is null)
            {
                context.Session.SetString("cart", JsonConvert.SerializeObject(new List<ProductBasketViewModel>()));
            }

            var cart = GetCartProducts(context);

            var srchProduct = cart.FirstOrDefault(p => p.Id == product.Id);
            if (srchProduct is null)
            {
                cart.Add(product);
            }
            else
            {
                srchProduct.Quantity += product.Quantity;
            }
            context.Session.SetString("cart", JsonConvert.SerializeObject(cart));
        }

        public void RemoveProductFromCart(HttpContext context, ProductBasketViewModel product)
        {
            if (context.Session.GetString("cart") is null)
            {
                context.Session.SetString("cart", JsonConvert.SerializeObject(new List<ProductBasketViewModel>()));
            }

            var cart = GetCartProducts(context);
            var srchProduct = cart.FirstOrDefault(p => p.Id == product.Id);
            cart.Remove(srchProduct);
            context.Session.SetString("cart", JsonConvert.SerializeObject(cart));
        }

        public List<ProductBasketViewModel> GetCartProducts(HttpContext context)
        {
            string json = context.Session.GetString("cart");
            return json is null ? new List<ProductBasketViewModel>() : JsonConvert.DeserializeObject<List<ProductBasketViewModel>>(json);
        }

        public void ClearCart(HttpContext context)
        {
            if (context.Session.GetString("cart") is null)
            {
                context.Session.SetString("cart", JsonConvert.SerializeObject(new List<ProductBasketViewModel>()));
            }

            var cart = GetCartProducts(context);
            cart.Clear();
            context.Session.SetString("cart", JsonConvert.SerializeObject(cart));
        }
    }
}
