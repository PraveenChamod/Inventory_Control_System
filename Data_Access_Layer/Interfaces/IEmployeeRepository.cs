using Data_Access_Layer.DTOs.Employee;

namespace Data_Access_Layer.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<GetEmployeeDto> GetAllEmployees();
        Guid? GetIdByEmployeeName(string name);
    }
}
