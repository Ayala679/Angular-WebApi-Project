using AutoMapper;
using Chinese_Auction.Dto_s;
using Chinese_Auction.Repository;
using Chinese_Auction.Models;

namespace Chinese_Auction.Services
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

        public async Task<IEnumerable<GetCategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return _mapper.Map<IEnumerable<GetCategoryDto>>(categories);
        }

        public async Task<GetCategoryDto?> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            return category == null ? null : _mapper.Map<GetCategoryDto>(category);
        }

        public async Task<GetCategoryDto> CreateCategoryAsync(CategoryDto createCategoryDto)
        {
            if (await CategoryNameExistsAsync(createCategoryDto.Name,-1))
                throw new Exception("Category with the same name already exists.");
            var category = _mapper.Map<Category>(createCategoryDto);

            await _categoryRepository.CreateCategoryAsync(category);
            return _mapper.Map<GetCategoryDto>(category);
        }

        public async Task<GetCategoryDto?> UpdateCategoryAsync(int id, CategoryDto updateCategoryDto)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(id);
            if (existingCategory == null) return null;
            if (await CategoryNameExistsAsync(updateCategoryDto.Name, -1))
                throw new Exception("Category with the same name already exists.");
            _mapper.Map(updateCategoryDto, existingCategory); 
            existingCategory.Id = id;
            var updatedCategory = await _categoryRepository.UpdateCategoryAsync(existingCategory);
            return updatedCategory == null ? null : _mapper.Map<GetCategoryDto>(updatedCategory);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(id);
            if (existingCategory == null) return false;
            await _categoryRepository.DeleteCategoryAsync(id);
            return true;
        }

        public async Task<bool> CategoryNameExistsAsync(string name,int id)
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return categories.Any(c => c.Name.Equals(name) && c.Id.Equals(id));
        }

    }
}
