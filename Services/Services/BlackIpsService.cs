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
    public class BlackIpsService : IService<int, IPAdressDTO>
    {
        IUnitOfWork uow;
        ObjectMapperBusiness mapper = ObjectMapperBusiness.Instance;
        public BlackIpsService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public  async Task Create(IPAdressDTO entityDTO)
        {
            await uow.BlackIpsRepository.Create(mapper.Mapper.Map<IPAdress>(entityDTO));
        }

        public  async Task<IPAdressDTO> Get(int id)
        {
            return mapper.Mapper.Map<IPAdressDTO>(await uow.BlackIpsRepository.Get(id));
        }

        public  async Task<List<IPAdressDTO>> GetAll()
        {
            return mapper.Mapper.Map<List<IPAdressDTO>>(await uow.BlackIpsRepository.GetAll());
        }

        public  async Task Remove(int id)
        {
            await uow.BlackIpsRepository.Remove(id);
        }

        public  async Task Update(IPAdressDTO entityDTO)
        {
            await uow.BlackIpsRepository.Update(mapper.Mapper.Map<IPAdress>(entityDTO));
        }
    }
}
