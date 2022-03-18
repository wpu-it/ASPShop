using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
        public List<Product> Products { get; set; }
        public List<SubCategory> SubCategories { get; set; }
        public int? CategoryPhotoId { get; set; }
        public CategoryPhoto CategoryPhoto { get; set; }
    }
}
