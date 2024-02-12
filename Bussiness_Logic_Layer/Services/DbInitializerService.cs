using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.Auth;
using Data_Access_Layer.DTOs.Employee;
using Data_Access_Layer.DTOs.Store;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System.Data;

namespace Bussiness_Logic_Layer.Services
{
    public class DbInitializerService : IDbInitializerService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmployeeService _employeeService;
        private readonly IStoreService _storeService;

        public DbInitializerService(RoleManager<IdentityRole> roleManager, IStoreService storeService, IEmployeeService employeeService)
        {
            _roleManager = roleManager;
            _employeeService = employeeService;
            _storeService = storeService;
        }
        public async Task Seed()
        {
            await SeedUserRoles();
            await SeedStores();
            await SeedEmployees();
        }

        private async Task SeedUserRoles()
        {
            string[] roles = { Roles.Admin, Roles.Operator, Roles.Manager };

            foreach (var roleName in roles)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        private async Task SeedStores()
        {
            var checkStores = _storeService.GetStoreList();
            if(checkStores.Count == 0)
            {
                var storeData = new List<CreateStoreDto>();
                using (StreamReader r = new(@"StoreData.json"))
                {
                    string json = r.ReadToEnd();
                    storeData = JsonConvert.DeserializeObject<List<CreateStoreDto>>(json);
                }
                if (storeData != null)
                {
                    foreach (var store in storeData)
                    {
                        var add = new CreateStoreDto
                        {
                            Id = store.Id,
                            StoreName = store.StoreName,
                            Phone = store.Phone,
                            Email = store.Email,
                            Street = store.Street,
                            City = store.City,
                            State = store.State,
                            PostalCode = store.PostalCode,
                            Country = store.Country,
                        };
                         await _storeService.CreateStore(add);
                    }
                }
            }
        }

        private async Task SeedEmployees()
        {
            var checkEmployees = _employeeService.GetEmployeeList();
            if (checkEmployees.Count == 0)
            {
                var employeeData = new List<CreateEmployeeDto>();
                using (StreamReader r = new(@"EmployeeData.json"))
                {
                    string json = r.ReadToEnd();
                    employeeData = JsonConvert.DeserializeObject<List<CreateEmployeeDto>>(json);
                }
                if (employeeData != null)
                {
                    foreach (var employee in employeeData)
                    {
                        var add = new CreateEmployeeDto
                        {
                            Id = employee.Id,
                            Name = employee.Name,
                            Designation = employee.Designation,
                            NIC = employee.NIC,
                            Phone = employee.Phone,
                            Email = employee.Email,
                            Password = employee.Password,
                            StoreId = employee.StoreId,
                        };
                        await _employeeService.CreateEmployee(add);
                    }
                }
            }
        }
    }
}
