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
    public class ProductsService : IProductsService
    {
        IUnitOfWork uow;
        ObjectMapperBusiness mapper = ObjectMapperBusiness.Instance;
        public ProductsService(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        public  async Task Create(ProductDTO entityDTO)
        {
            await uow.ProductsRepository.Create(mapper.Mapper.Map<Product>(entityDTO));
        }

        public  async Task<ProductDTO> Get(int id)
        {
            return mapper.Mapper.Map<ProductDTO>(await uow.ProductsRepository.Get(id));
        }

        public  async Task<List<ProductDTO>> GetAll()
        {
            return mapper.Mapper.Map<List<ProductDTO>>(await uow.ProductsRepository.GetAll());
        }

        public  async Task Remove(int id)
        {
            await uow.ProductsRepository.Remove(id);
        }

        public  async Task Update(ProductDTO entityDTO)
        {
            await uow.ProductsRepository.Update(mapper.Mapper.Map<Product>(entityDTO));
        }

        public async Task AddToWishList(ProductDTO entityDTO, User user)
        {
            var prod = mapper.Mapper.Map<Product>(entityDTO);
            prod.Users.Add(user);
            await uow.ProductsRepository.UpdateWishList(prod);
        }

        public async Task RemoveFromWishList(ProductDTO product, User user)
        {
            var prod = mapper.Mapper.Map<Product>(product);
            await uow.ProductsRepository.RemoveFromWishList(prod, user.Id);
        }
    }
}
