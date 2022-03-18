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
    public class SubCategoriesService : IService<int, SubCategoryDTO>
    {
        IUnitOfWork uow;
        ObjectMapperBusiness mapper = ObjectMapperBusiness.Instance;
        public SubCategoriesService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public  async Task Create(SubCategoryDTO entityDTO)
        {
            await uow.SubCategoriesRepository.Create(mapper.Mapper.Map<SubCategory>(entityDTO));
        }

        public  async Task<SubCategoryDTO> Get(int id)
        {
            return mapper.Mapper.Map<SubCategoryDTO>(await uow.SubCategoriesRepository.Get(id));
        }

        public  async Task<List<SubCategoryDTO>> GetAll()
        {
            return mapper.Mapper.Map<List<SubCategoryDTO>>(await uow.SubCategoriesRepository.GetAll());
        }

        public  async Task Remove(int id)
        {
            await uow.SubCategoriesRepository.Remove(id);
        }

        public  async Task Update(SubCategoryDTO entityDTO)
        {
            await uow.SubCategoriesRepository.Update(mapper.Mapper.Map<SubCategory>(entityDTO));
        }
    }
}
