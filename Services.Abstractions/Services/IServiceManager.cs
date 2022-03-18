using Services.Abstractions.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions.Services
{
    public interface IServiceManager
    {
        IService<int, CategoryDTO> CategoriesService { get; }
        IService<int, CharacteristicDTO> CharacteristicsService { get; }
        IService<int, ProductPhotoDTO> PhotosService { get; }
        IService<int, ProducerDTO> ProducersService { get; }
        IProductsService ProductsService { get; }
        IService<int, IPAdressDTO> BlackIpsService { get; }
        IService<int, SubCategoryDTO> SubCategoriesService { get; }
        IService<int, CategoryPhotoDTO> CategoryPhotosService { get; }
        IOrdersService OrdersService { get; }
        IUsersService UsersService { get; }
    }
}
