using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.Auth;
using Data_Access_Layer.Entities.Enums;
using Data_Access_Layer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Bussiness_Logic_Layer.Services
{
    public class DbInitializerService : IDbInitializerService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public DbInitializerService(RoleManager<IdentityRole> roleManager, IConfiguration configuration, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _configuration = configuration;
            _userManager = userManager;
        }
        public async Task Seed()
        {
            await SeedAdminUser();
            await SeedUserRoles();
            
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

        private async Task SeedAdminUser()
        {
            var userSettings = _configuration.GetSection("UserSetting");
            var superPassword = userSettings["SuperPassword"];

            if (!string.IsNullOrEmpty(superPassword))
            {
                await CreateAndSeedUser("Admin", "admin.user@gmail.com", UserRoles.Admin.ToString(), superPassword);
            }
        }

        private async Task CreateAndSeedUser(string role, string email, string roleName, string password)
        {
            User user = new()
            {
                FirstName = role,
                LastName = "User",
                CreatedDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow,
                Email = email,
                UserName = email,
                UserStatus = UserStatus.Active
            };

            IdentityResult result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}
