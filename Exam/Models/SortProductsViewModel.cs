using Services.Abstractions.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class SortProductsViewModel
    {
        public List<ProductDTO> Products { get; set; }
    }
}
