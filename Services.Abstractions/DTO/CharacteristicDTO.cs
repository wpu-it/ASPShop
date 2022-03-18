using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.DTO
{
    public class CharacteristicDTO : BaseDTO<int>
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int? ProductId { get; set; }
        public ProductDTO Product { get; set; }
    }
}
