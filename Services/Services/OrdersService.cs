using Domain.Entities;
using Domain.Repositories;
using Services.Abstractions.DTO;
using Services.Abstractions.Services;
using Services.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class OrdersService : IOrdersService
    {
        IUnitOfWork uow;
        ObjectMapperBusiness mapper = ObjectMapperBusiness.Instance;
        public OrdersService(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public  async Task Create(OrderDTO entityDTO)
        {
            await uow.OrdersRepository.Create(mapper.Mapper.Map<Order>(entityDTO));
        }

        public  async Task<OrderDTO> Get(int id)
        {
            return mapper.Mapper.Map<OrderDTO>(await uow.OrdersRepository.Get(id));
        }

        public  async Task<List<OrderDTO>> GetAll()
        {
            return mapper.Mapper.Map<List<OrderDTO>>(await uow.OrdersRepository.GetAll());
        }

        public  async Task Remove(int id)
        {
            await uow.OrdersRepository.Remove(id);
        }

        public  async Task Update(OrderDTO entityDTO)
        {
            await uow.OrdersRepository.Update(mapper.Mapper.Map<Order>(entityDTO));
        }

        public async Task UpdateProducts(OrderDTO newOrder)
        {
            await uow.OrdersRepository.UpdateProducts(mapper.Mapper.Map<Order>(newOrder));
        }
    }
}
