using AutoMapper;
using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.DTOs.Employee;
using Data_Access_Layer.DTOs.User;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Entities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bussiness_Logic_Layer.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public async Task<GetUserDto> RegisterUser(CreateEmployeeDto employeeData)
        {
            try
            {
                var existingUser = await _userManager.FindByEmailAsync(employeeData.Email);
                if (existingUser != null)
                {
                    throw new Exception("A user with the same email already exists.");
                }

                Employee employee = _mapper.Map<Employee>(employeeData);
                CreateUserDto newUser = new()
                {
                    FirstName = employee.Name!.Split(" ")[0],
                    LastName = employee.Name!.Split(" ")[1] ?? "",
                    Role = employee.Designation,
                    Email = employee.Email,
                    PhoneNumber = employee.Phone,
                    UserName = employee.Email,
                    UserStatus = UserStatus.Active,
                    CreatedDate = DateTime.UtcNow,
                    UpdatedDate = DateTime.UtcNow,
                    Employee = employeeData,
                };

                User user = _mapper.Map<User>(newUser);

                IdentityResult result = await _userManager.CreateAsync(user, employee.Password!);

                if (!result.Succeeded)
                {
                    throw new Exception("User creation failed.");
                }

                var userRole = employee.Designation;
                var roleName = userRole.ToString().Split(" ").ElementAt(0);
                var identityRole = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Name == roleName) ?? null;
                if (identityRole == null)
                {
                    identityRole = new IdentityRole(roleName);
                    await _roleManager.CreateAsync(identityRole);
                }
                await _userManager.AddToRoleAsync(user, identityRole.Name!);

                var createdEmployee = await _userManager.FindByEmailAsync(newUser.Email!);
                return _mapper.Map<GetUserDto>(createdEmployee);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
