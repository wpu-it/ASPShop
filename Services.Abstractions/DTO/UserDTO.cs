using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.DTO
{
    public class UserDTO
    {
        public List<ProductDTO> Products { get; set; }
        public List<OrderDTO> Orders { get; set; }
    }
}
