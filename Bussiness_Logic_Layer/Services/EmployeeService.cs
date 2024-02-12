using AutoMapper;
using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.DTOs.Employee;
using Data_Access_Layer.Interfaces;

namespace Bussiness_Logic_Layer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public List<GetEmployeeDto> GetEmployeeList()
        {
            var employees = _employeeRepository.GetAllEmployees().Select(entity => _mapper.Map<GetEmployeeDto>(entity)).ToList();
            return employees;
        }

        public async Task<GetEmployeeDto> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            var name = createEmployeeDto.Name;
            var existingEmployee = _employeeRepository.GetAllEmployees().FirstOrDefault(store => store.Name == name);

            if (existingEmployee != null)
            {
                throw new Exception("Employee with the same name already exists.");
            }

            var createdEmployee = await _employeeRepository.CreateEmployee(createEmployeeDto);

            return _mapper.Map<GetEmployeeDto>(createdEmployee);
        }
    }
}
