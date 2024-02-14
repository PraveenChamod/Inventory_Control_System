using AutoMapper;
using Data_Access_Layer.DTOs.Category;
using Data_Access_Layer.DTOs.Employee;
using Data_Access_Layer.DTOs.Inventory;
using Data_Access_Layer.DTOs.Product;
using Data_Access_Layer.DTOs.Store;
using Data_Access_Layer.DTOs.Supplier;
using Data_Access_Layer.DTOs.User;
using Data_Access_Layer.Entities;

namespace Presentation_Layer
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Store, GetStoreDto>();
            CreateMap<GetStoreDto, Store>();

            CreateMap<Category, GetCategoryDto>();
            CreateMap<GetCategoryDto, Category>();

            CreateMap<Employee, GetEmployeeDto>();
            CreateMap<GetEmployeeDto, Employee>();

            CreateMap<Employee, CreateEmployeeDto>();
            CreateMap<CreateEmployeeDto, Employee>();

            CreateMap<Supplier, GetSupplierDto>();
            CreateMap<GetSupplierDto, Supplier>();

            CreateMap<User, CreateUserDto>();
            CreateMap<CreateUserDto, User>();
            
            CreateMap<User, GetUserDto>();
            CreateMap<CreateUserDto, GetUserDto>();

            CreateMap<CreateEmployeeDto, GetEmployeeDto>();

            CreateMap<Product, GetProductDto>();
            CreateMap<GetProductDto, Product>();

            CreateMap<Inventory, GetInventoryDto>();
            CreateMap<GetInventoryDto, Inventory>();

            CreateMap<Inventory, UpdateInventoryDto>();
            CreateMap<UpdateInventoryDto, Inventory>();
        }
    }
}
