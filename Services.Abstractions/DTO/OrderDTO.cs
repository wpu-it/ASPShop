using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.DTO
{
    public class OrderDTO : BaseDTO<int>
    {
        public int Number { get; set; }
        public int Postnumber { get; set; }
        public string PhoneNumber { get; set; }
        public string? UserId { get; set; }
        public UserDTO User { get; set; }
        public List<ProductDTO> Products { get; set; }
        public decimal OverallPrice { get; set; }
    }
}
