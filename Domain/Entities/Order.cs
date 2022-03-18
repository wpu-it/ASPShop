using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : BaseEntity<int>
    {
        public int Number { get; set; }
        public int PostNumber { get; set; }
        public string PhoneNumber { get; set; }
        public decimal OverallPrice { get; set; }
        public string? UserId { get; set; }
        public User User { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
