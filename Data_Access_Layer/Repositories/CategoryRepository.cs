using Data_Access_Layer.Context;
using Data_Access_Layer.DTOs.Category;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Entities.Enums;
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

        public async Task<Category> CreateCategory(CreateCategoryDto createCategoryDto, Guid? employeeId)
        {
            var newCategory = new Category
            {
                CategoryName = createCategoryDto.CategoryName,
                Description = createCategoryDto.Description,
                CategoryStatus = createCategoryDto.CategoryStatus,
            };
            _dbContext.Categories.Add(newCategory);
            await _dbContext.SaveChangesAsync();
            if (employeeId != null)
            {
                await UpdateManageCategory((Guid)newCategory.Id!, (Guid)employeeId!, ManageItem.Create);
            }
            return newCategory;
        }

        public async Task UpdateManageCategory(Guid categoryId, Guid employeeId, ManageItem description)
        {
            var manageCategory = new ManageCategory
            {
                CategoryId = categoryId,
                EmployeeId = employeeId,
                Description = description,
                UpdateDate = DateTime.UtcNow,
                UpdateTime = DateTime.UtcNow
            };

            _dbContext.ManageCategories.Add(manageCategory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Category> UpdateCategory(Guid categoryId, UpdateCategoryDto updateCategoryDto, Guid? employeeId)
        {
            var category = await _dbContext.Categories.FindAsync(categoryId);

            if (category != null)
            {
                category.CategoryName = updateCategoryDto.CategoryName;
                category.CategoryStatus = updateCategoryDto.CategoryStatus;
                category.Description = updateCategoryDto.Description;


                _dbContext.Categories.Update(category);
                await _dbContext.SaveChangesAsync();

                if (employeeId != null)
                {
                    await UpdateManageCategory((Guid)category.Id!, (Guid)employeeId!, ManageItem.Update);
                }
            }
            return category!;
        }

        public async Task SoftDeleteCategory(Guid categoryId, Guid employeeId)
        {
            var category = await _dbContext.Categories.FindAsync(categoryId);

            if (category != null)
            {
                category.CategoryStatus = ItemStatus.Inactive;
                _dbContext.Categories.Update(category);
                await UpdateManageCategory(categoryId!, employeeId!, ManageItem.Remove);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
