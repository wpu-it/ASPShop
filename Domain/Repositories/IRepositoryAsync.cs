using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRepositoryAsync<TKey, TValue>
        where TKey : struct
        where TValue : BaseEntity<TKey>
    {
        Task Create(TValue entity);
        Task<TValue> Get(TKey id, CancellationToken cancellationToken = default);
        Task<List<TValue>> GetAll(CancellationToken cancellationToken = default);
        Task<List<TValue>> GetAll(Func<TValue, bool> predicate, CancellationToken cancellationToken = default);
        Task Remove(TKey id);
        Task Update(TValue entity);
    }
}
