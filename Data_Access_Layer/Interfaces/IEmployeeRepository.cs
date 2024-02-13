using Data_Access_Layer.DTOs.Employee;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<GetEmployeeDto> GetAllEmployees();
        Guid? GetIdByEmployeeName(string name);
    }
}
