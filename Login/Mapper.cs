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
            CreateMap<User, UserLoginDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
        }
    }
}
