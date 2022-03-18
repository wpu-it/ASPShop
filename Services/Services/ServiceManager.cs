using Domain.Repositories;
using Services.Abstractions.DTO;
using Services.Abstractions.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ServiceManager : IServiceManager
    {
        readonly Lazy<IService<int, CategoryDTO>> _categoriesService;
        readonly Lazy<IService<int, CharacteristicDTO>> _characteristicsService;
        readonly Lazy<IService<int, ProductPhotoDTO>> _photosService;
        readonly Lazy<IService<int, ProducerDTO>> _producersService;
        readonly Lazy<IProductsService> _productsService;
        readonly Lazy<IService<int, IPAdressDTO>> _blackIpsService;
        readonly Lazy<IService<int, SubCategoryDTO>> _subCategoriesService;
        readonly Lazy<IService<int, CategoryPhotoDTO>> _categoryPhotosService;
        readonly Lazy<IOrdersService> _ordersService;
        readonly Lazy<IUsersService> _usersService;
        public IService<int, CategoryDTO> CategoriesService => _categoriesService.Value;

        public IService<int, CharacteristicDTO> CharacteristicsService => _characteristicsService.Value;

        public IService<int, ProductPhotoDTO> PhotosService => _photosService.Value;

        public IService<int, ProducerDTO> ProducersService => _producersService.Value;

        public IProductsService ProductsService => _productsService.Value;

        public IService<int, IPAdressDTO> BlackIpsService => _blackIpsService.Value;

        public IService<int, SubCategoryDTO> SubCategoriesService => _subCategoriesService.Value;

        public IService<int, CategoryPhotoDTO> CategoryPhotosService => _categoryPhotosService.Value;

        public IOrdersService OrdersService => _ordersService.Value;

        public IUsersService UsersService => _usersService.Value;

        public ServiceManager(IUnitOfWork uow)
        {
            _categoriesService = new Lazy<IService<int, CategoryDTO>>(() => new CategoriesService(uow));
            _characteristicsService = new Lazy<IService<int, CharacteristicDTO>>(() => new CharacteristicsService(uow));
            _photosService = new Lazy<IService<int, ProductPhotoDTO>>(() => new PhotosService(uow));
            _producersService = new Lazy<IService<int, ProducerDTO>>(() => new ProducersService(uow));
            _productsService = new Lazy<IProductsService>(() => new ProductsService(uow));
            _blackIpsService = new Lazy<IService<int, IPAdressDTO>>(() => new BlackIpsService(uow));
            _subCategoriesService = new Lazy<IService<int, SubCategoryDTO>>(() => new SubCategoriesService(uow));
            _categoryPhotosService = new Lazy<IService<int, CategoryPhotoDTO>>(() => new CategoryPhotosService(uow));
            _ordersService = new Lazy<IOrdersService>(() => new OrdersService(uow));
            _usersService = new Lazy<IUsersService>(() => new UsersService(uow));
        }
    }
}
