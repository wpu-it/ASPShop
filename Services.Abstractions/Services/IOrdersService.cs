using Services.Abstractions.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.Services
{
    public interface IOrdersService : IService<int, OrderDTO>
    {
        Task UpdateProducts(OrderDTO newOrder);
    }
}
