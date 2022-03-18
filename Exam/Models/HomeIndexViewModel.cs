using Services.Abstractions.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class HomeIndexViewModel
    {
        public List<CategoryDTO> Categories { get; set; }
        public List<SubCategoryDTO> SubCategories { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
