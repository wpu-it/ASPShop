using Domain.Entities;
using Services.Abstractions.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.Services
{
    public interface IService<TKey, TValue>
        where TKey : struct
        where TValue : BaseDTO<TKey>
    {
        Task Create(TValue entityDTO);
        Task<TValue> Get(TKey id);
        Task<List<TValue>> GetAll();
        Task Remove(int id);
        Task Update(TValue entityDTO);
    }
}
