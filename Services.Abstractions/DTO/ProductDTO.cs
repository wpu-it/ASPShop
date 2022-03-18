using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.DTO
{
    public class ProductDTO : BaseDTO<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
        public int? SubCategoryId { get; set; }
        public SubCategoryDTO SubCategory { get; set; }
        public int? ProducerId { get; set; }
        public ProducerDTO Producer { get; set; }
        public List<ProductPhotoDTO> ProductPhotos { get; set; }
        public List<CharacteristicDTO> Characteristics { get; set; }
        public List<UserDTO> Users { get; set; }
        public List<OrderDTO> Orders { get; set; }
    }
}
