using Data_Access_Layer.DTOs.Category;
using Data_Access_Layer.DTOs.Product;
using Data_Access_Layer.DTOs.Supplier;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Entities.Enums;

namespace Data_Access_Layer.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<GetCategoryDto> GetAllCategories();
        Guid? GetIdByCategoryName(string name);
        Task<Category> CreateCategory(CreateCategoryDto createCategory, Guid? employeeId);
        Task UpdateManageCategory(Guid categoryId, Guid employeeId, ManageItem description);
        Task<Category> UpdateCategory(Guid categoryId, UpdateCategoryDto updateCategory, Guid? employeeId);
        Task SoftDeleteCategory(Guid categoryId, Guid employeeId);

    }
}
