using AutoMapper;
using Domain.Entities;
using Services.Abstractions.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Automapper.Profiles
{
    public class MappingProfileBusiness : Profile
    {
        public MappingProfileBusiness()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Characteristic, CharacteristicDTO>().ReverseMap();
            CreateMap<ProductPhoto, ProductPhotoDTO>().ReverseMap();
            CreateMap<Producer, ProducerDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<IPAdress, IPAdressDTO>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDTO>().ReverseMap();
            CreateMap<CategoryPhoto, CategoryPhotoDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
