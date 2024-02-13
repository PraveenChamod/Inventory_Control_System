using AutoMapper;
using Data_Access_Layer.DTOs.Employee;
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

        }
    }
}
