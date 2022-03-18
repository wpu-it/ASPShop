using Domain.Entities;
using Domain.Repositories;
using Persistence.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly Lazy<IRepositoryAsync<int, Category>> _categoriesRepository;
        readonly Lazy<IRepositoryAsync<int, Characteristic>> _characteristicsRepository;
        readonly Lazy<IRepositoryAsync<int, ProductPhoto>> _photosRepository;
        readonly Lazy<IRepositoryAsync<int, Producer>> _producersRepository;
        readonly Lazy<IProductsRepository> _productsRepository;
        readonly Lazy<IRepositoryAsync<int, IPAdress>> _blackIpsRepository;
        readonly Lazy<IRepositoryAsync<int, SubCategory>> _subCategoriesRepository;
        readonly Lazy<IRepositoryAsync<int, CategoryPhoto>> _categoryPhotosRepository;
        readonly Lazy<IOrdersRepository> _ordersRepository;
        readonly Lazy<IUsersRepository> _usersRepository;

        public IRepositoryAsync<int, Category> CategoriesRepository => _categoriesRepository.Value;

        public IRepositoryAsync<int, Characteristic> CharacteristicsRepository => _characteristicsRepository.Value;

        public IRepositoryAsync<int, ProductPhoto> PhotosRepository => _photosRepository.Value;

        public IRepositoryAsync<int, Producer> ProducersRepository => _producersRepository.Value;

        public IProductsRepository ProductsRepository => _productsRepository.Value;

        public IRepositoryAsync<int, IPAdress> BlackIpsRepository => _blackIpsRepository.Value;

        public IRepositoryAsync<int, SubCategory> SubCategoriesRepository => _subCategoriesRepository.Value;

        public IRepositoryAsync<int, CategoryPhoto> CategoryPhotosRepository => _categoryPhotosRepository.Value;

        public IOrdersRepository OrdersRepository => _ordersRepository.Value;

        public IUsersRepository UsersRepository => _usersRepository.Value;

        public UnitOfWork(ApplicationContext db)
        {
            _categoriesRepository = new Lazy<IRepositoryAsync<int, Category>>(() => new CategoriesRepository(db));
            _characteristicsRepository = new Lazy<IRepositoryAsync<int, Characteristic>>(() => new CharacteristicsRepository(db));
            _photosRepository = new Lazy<IRepositoryAsync<int, ProductPhoto>>(() => new ProductPhotosRepository(db));
            _producersRepository = new Lazy<IRepositoryAsync<int, Producer>>(() => new ProducersRepository(db));
            _productsRepository = new Lazy<IProductsRepository>(() => new ProductsRepository(db));
            _blackIpsRepository = new Lazy<IRepositoryAsync<int, IPAdress>>(() => new BlackIpsRepository(db));
            _subCategoriesRepository = new Lazy<IRepositoryAsync<int, SubCategory>>(() => new SubCategoriesRepository(db));
            _categoryPhotosRepository = new Lazy<IRepositoryAsync<int, CategoryPhoto>>(() => new CategoryPhotosRepository(db));
            _ordersRepository = new Lazy<IOrdersRepository>(() => new OrdersRepository(db));
            _usersRepository = new Lazy<IUsersRepository>(() => new UsersRepository(db));
        }
    }
}
