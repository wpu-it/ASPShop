using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class NewOrderViewModel
    {
        public List<ProductBasketViewModel> Products { get; set; }
        public User User { get; set; }
        public decimal OverallPrice { get; set; }
    }
}
