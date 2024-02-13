using Data_Access_Layer.DTOs.Employee;
using Data_Access_Layer.DTOs.User;

namespace Bussiness_Logic_Layer.Interfaces
{
    public interface IUserService
    {
        Task<GetUserDto> RegisterUser(CreateEmployeeDto user);
    }
}
