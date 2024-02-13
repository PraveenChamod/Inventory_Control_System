using Data_Access_Layer.DTOs.User;

namespace Bussiness_Logic_Layer.Interfaces
{
    public interface IAuthService
    {
        Task<bool> ValidateUser(LoginUserDto loginUserDto);
        Task<string> GenerateToken();
    }
}
