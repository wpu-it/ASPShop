using Services.Abstractions.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class SubCategoryViewModel
    {
        public SubCategoryDTO SubCategory { get; set; }
        public List<ProductDTO> Products { get; set; }
        public List<ProducerDTO> Producers { get; set; }
        public int OverallProductsCount { get; set; }
        public int Page { get; set; }
    }
}
