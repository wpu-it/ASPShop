using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUnitOfWork
    {
        IRepositoryAsync<int, Category> CategoriesRepository { get; }
        IRepositoryAsync<int, Characteristic> CharacteristicsRepository { get; }
        IRepositoryAsync<int, ProductPhoto> PhotosRepository { get; }
        IRepositoryAsync<int, Producer> ProducersRepository { get; }
        IProductsRepository ProductsRepository { get; }
        IRepositoryAsync<int, IPAdress> BlackIpsRepository { get; }
        IRepositoryAsync<int, SubCategory> SubCategoriesRepository { get; }
        IRepositoryAsync<int, CategoryPhoto> CategoryPhotosRepository { get; }
        IOrdersRepository OrdersRepository { get; }
        IUsersRepository UsersRepository { get; }
    }
}
