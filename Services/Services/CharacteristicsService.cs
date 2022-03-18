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
    public class CharacteristicsService : IService<int, CharacteristicDTO>
    {
        IUnitOfWork uow;
        ObjectMapperBusiness mapper = ObjectMapperBusiness.Instance;
        public CharacteristicsService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public  async Task Create(CharacteristicDTO entityDTO)
        {
            await uow.CharacteristicsRepository.Create(mapper.Mapper.Map<Characteristic>(entityDTO));
        }

        public  async Task<CharacteristicDTO> Get(int id)
        {
            return mapper.Mapper.Map<CharacteristicDTO>(await uow.CharacteristicsRepository.Get(id));
        }

        public  async Task<List<CharacteristicDTO>> GetAll()
        {
            return mapper.Mapper.Map<List<CharacteristicDTO>>(await uow.CharacteristicsRepository.GetAll());
        }

        public  async Task Remove(int id)
        {
            await uow.CharacteristicsRepository.Remove(id);
        }

        public  async Task Update(CharacteristicDTO entityDTO)
        {
            await uow.CharacteristicsRepository.Update(mapper.Mapper.Map<Characteristic>(entityDTO));
        }
    }
}
