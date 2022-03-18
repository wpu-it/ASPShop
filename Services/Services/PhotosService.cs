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
    public class PhotosService : IService<int, ProductPhotoDTO>
    {
        IUnitOfWork uow;
        ObjectMapperBusiness mapper = ObjectMapperBusiness.Instance;
        public PhotosService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public  async Task Create(ProductPhotoDTO entityDTO)
        {
            await uow.PhotosRepository.Create(mapper.Mapper.Map<ProductPhoto>(entityDTO));
        }

        public  async Task<ProductPhotoDTO> Get(int id)
        {
            return mapper.Mapper.Map<ProductPhotoDTO>(await uow.PhotosRepository.Get(id));
        }

        public  async Task<List<ProductPhotoDTO>> GetAll()
        {
            return mapper.Mapper.Map<List<ProductPhotoDTO>>(await uow.PhotosRepository.GetAll());
        }

        public  async Task Remove(int id)
        {
            await uow.PhotosRepository.Remove(id);
        }

        public  async Task Update(ProductPhotoDTO entityDTO)
        {
            await uow.PhotosRepository.Update(mapper.Mapper.Map<ProductPhoto>(entityDTO));
        }
    }
}
