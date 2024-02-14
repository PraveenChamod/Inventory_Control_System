using Data_Access_Layer.DTOs.Category;

namespace Bussiness_Logic_Layer.Interfaces
{
    public interface ICategoryService
    {
        List<GetCategoryDto> GetCategoryList();
        Task<GetCategoryDto> CreateCategory(CreateCategoryDto createCategoryDto, Guid employeeId);
        Task<GetCategoryDto> UpdateCategory(Guid categoryId, UpdateCategoryDto updateCategoryDto, Guid employeeId);
        Task SoftDeleteCategory(Guid categoryId, Guid employeeId);

    }
}
