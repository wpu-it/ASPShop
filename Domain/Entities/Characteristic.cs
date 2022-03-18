using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Characteristic : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    }
}
