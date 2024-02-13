using Data_Access_Layer.DTOs.Employee;

namespace Bussiness_Logic_Layer.Interfaces
{
    public interface IEmployeeService
    {
        List<GetEmployeeDto> GetEmployeeList();
    }
}
