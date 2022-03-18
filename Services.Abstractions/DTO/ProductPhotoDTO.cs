using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.DTO
{
    public class ProductPhotoDTO : BaseDTO<int>
    {
        public string Path { get; set; }
        public int? ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
}
