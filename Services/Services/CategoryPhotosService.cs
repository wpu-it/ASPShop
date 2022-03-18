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
    public class CategoryPhotosService : IService<int, CategoryPhotoDTO>
    {
        IUnitOfWork uow;
        ObjectMapperBusiness mapper = ObjectMapperBusiness.Instance;
        public CategoryPhotosService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public  async Task Create(CategoryPhotoDTO entityDTO)
        {
            await uow.CategoryPhotosRepository.Create(mapper.Mapper.Map<CategoryPhoto>(entityDTO));
        }

        public  async Task<CategoryPhotoDTO> Get(int id)
        {
            return mapper.Mapper.Map<CategoryPhotoDTO>(await uow.CategoryPhotosRepository.Get(id));
        }

        public  async Task<List<CategoryPhotoDTO>> GetAll()
        {
            return mapper.Mapper.Map<List<CategoryPhotoDTO>>(await uow.CategoryPhotosRepository.GetAll());
        }

        public  async Task Remove(int id)
        {
            await uow.CategoryPhotosRepository.Remove(id);
        }

        public  async Task Update(CategoryPhotoDTO entityDTO)
        {
            await uow.CategoryPhotosRepository.Update(mapper.Mapper.Map<CategoryPhoto>(entityDTO));
        }
    }
}
