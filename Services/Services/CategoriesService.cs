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
    public class CategoriesService : IService<int, CategoryDTO>
    {
        IUnitOfWork uow;
        ObjectMapperBusiness mapper = ObjectMapperBusiness.Instance;
        public CategoriesService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public  async Task Create(CategoryDTO entityDTO)
        {
            await uow.CategoriesRepository.Create(mapper.Mapper.Map<Category>(entityDTO));
        }

        public  async Task<CategoryDTO> Get(int id)
        {
            return mapper.Mapper.Map<CategoryDTO>(await uow.CategoriesRepository.Get(id));
        }

        public  async Task<List<CategoryDTO>> GetAll()
        {
            return mapper.Mapper.Map<List<CategoryDTO>>(await uow.CategoriesRepository.GetAll());
        }

        public  async Task Remove(int id)
        {
            await uow.CategoriesRepository.Remove(id);
        }

        public  async Task Update(CategoryDTO entityDTO)
        {
            await uow.CategoriesRepository.Update(mapper.Mapper.Map<Category>(entityDTO));
        }
    }
}
