using AutoMapper;
using Bussiness_Logic_Layer.Interfaces;
using Data_Access_Layer.DTOs.Category;
using Data_Access_Layer.Interfaces;

namespace Bussiness_Logic_Layer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public List<GetCategoryDto> GetCategoryList()
        {
            var categories = _categoryRepository.GetAllCategories().Select(entity => _mapper.Map<GetCategoryDto>(entity)).ToList();
            return categories;
        }

        public async Task<GetCategoryDto> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var name = createCategoryDto.CategoryName;
            var existingCategory = _categoryRepository.GetAllCategories().FirstOrDefault(category => category.CategoryName == name);

            if (existingCategory != null)
            {
                throw new Exception("Category with the same name already exists.");
            }

            var createdCategory = await _categoryRepository.CreateCategory(createCategoryDto);

            return _mapper.Map<GetCategoryDto>(createdCategory);
        }
    }
}
