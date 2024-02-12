using Data_Access_Layer.Context;
using Data_Access_Layer.DTOs.Employee;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Interfaces;

namespace Data_Access_Layer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<GetEmployeeDto> GetAllEmployees()
        {
            return _dbContext.Employees
                .Select(s => new GetEmployeeDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Designation = s.Designation,
                    NIC = s.NIC,
                    Phone = s.Phone,
                    Email = s.Email,
                    Password = s.Password,
                    StoreId = s.StoreId,
                })
                .ToList();
        }

        public Guid? GetIdByEmployeeName(string name)
        {
            var id = _dbContext.Employees
                .Where(t => t.Name!.Replace(" ", string.Empty) == name)
                .FirstOrDefault()?
                .Id;
            return id;
        }

        public async Task<Employee> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            var newEmployee = new Employee
            {
                Id = createEmployeeDto.Id,
                Name = createEmployeeDto.Name,
                Designation = createEmployeeDto.Designation,
                NIC = createEmployeeDto.NIC,
                Phone = createEmployeeDto.Phone,
                Email = createEmployeeDto.Email,
                Password = createEmployeeDto.Password,
                StoreId = createEmployeeDto.StoreId,
            };
            _dbContext.Employees.Add(newEmployee);
            await _dbContext.SaveChangesAsync();
            return newEmployee;
        }
    }
}
