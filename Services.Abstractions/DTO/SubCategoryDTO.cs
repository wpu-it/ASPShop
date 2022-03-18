using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.DTO
{
    public class SubCategoryDTO : BaseDTO<int>
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
