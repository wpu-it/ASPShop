using Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Services
{
    public interface IWishListService
    {
        Task<int> GetWishListCount();
        Task<List<ProductBasketViewModel>> GetWishList();
    }
}
