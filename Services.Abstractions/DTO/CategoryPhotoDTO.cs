using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.DTO
{
    public class CategoryPhotoDTO : BaseDTO<int>
    {
        public string Path { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
