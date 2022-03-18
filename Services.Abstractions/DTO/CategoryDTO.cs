using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.DTO
{
    public class CategoryDTO : BaseDTO<int>
    {
        public string Name { get; set; }
        public List<ProductDTO> Products { get; set; }
        public List<SubCategoryDTO> SubCategories { get; set; }
        public int? CategoryPhotoId { get; set; }
        public CategoryPhotoDTO CategoryPhoto { get; set; }
    }
}
