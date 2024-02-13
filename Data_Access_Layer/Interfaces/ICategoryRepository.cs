using Data_Access_Layer.DTOs.Category;
using Data_Access_Layer.Entities;

namespace Data_Access_Layer.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<GetCategoryDto> GetAllCategories();
        Guid? GetIdByCategoryName(string name);
        Task<Category> CreateCategory(CreateCategoryDto createCategory);
    }
}
