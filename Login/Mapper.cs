using AutoMapper;
using DTO;
using Entities.Models;

namespace MyFirstWebApi
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
        }
    }
}
