using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.DTO
{
    public class BaseDTO<TKey>
        where TKey : struct
    {
        public TKey Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
