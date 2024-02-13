using Data_Access_Layer.Context;
using Data_Access_Layer.DTOs.Category;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Interfaces;

namespace Data_Access_Layer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<GetCategoryDto> GetAllCategories()
        {
            return _dbContext.Categories
                .Select(s => new GetCategoryDto
                {
                    Id = s.Id,
                    CategoryName = s.CategoryName,
                    Description = s.Description,
                    CategoryStatus = s.CategoryStatus,
                })
                .ToList();
        }

        public Guid? GetIdByCategoryName(string name)
        {
            var id = _dbContext.Categories
                .Where(t => t.CategoryName!.Replace(" ", string.Empty) == name)
                .FirstOrDefault()?
                .Id;
            return id;
        }

        public async Task<Category> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var newCategory = new Category
            {
                CategoryName = createCategoryDto.CategoryName,
                Description = createCategoryDto.Description,
                CategoryStatus = createCategoryDto.CategoryStatus,
            };
            _dbContext.Categories.Add(newCategory);
            await _dbContext.SaveChangesAsync();
            return newCategory;
        }
    }
}
