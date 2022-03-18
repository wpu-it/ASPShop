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
    public class ProducersService : IService<int, ProducerDTO>
    {
        IUnitOfWork uow;
        ObjectMapperBusiness mapper = ObjectMapperBusiness.Instance;
        public ProducersService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public  async Task Create(ProducerDTO entityDTO)
        {
            await uow.ProducersRepository.Create(mapper.Mapper.Map<Producer>(entityDTO));
        }

        public  async Task<ProducerDTO> Get(int id)
        {
            return mapper.Mapper.Map<ProducerDTO>(await uow.ProducersRepository.Get(id));
        }

        public  async Task<List<ProducerDTO>> GetAll()
        {
            return mapper.Mapper.Map<List<ProducerDTO>>(await uow.ProducersRepository.GetAll());
        }

        public  async Task Remove(int id)
        {
            await uow.ProducersRepository.Remove(id);
        }

        public  async Task Update(ProducerDTO entityDTO)
        {
            await uow.ProducersRepository.Update(mapper.Mapper.Map<Producer>(entityDTO));
        }
    }
}
