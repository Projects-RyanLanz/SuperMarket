using SuperMarket.DTO;
using SuperMarket.Models;
using SuperMarket.Repositories;

namespace SuperMarket.Services;

public class CategoryService {

    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository){
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetAll() => await _categoryRepository.GetAll();

    public async Task<Category?> GetById(int id) => await _categoryRepository.GetById(id);

    public async Task Create(CategoryDTO categoryDTO) {

        Validate(categoryDTO);

        await _categoryRepository.Create(categoryDTO);
    }

    public async Task Update(int id,CategoryDTO categoryDTO) {
    
        Validate(categoryDTO);

        await _categoryRepository.Update(id,categoryDTO);
    }

    public async Task Delete(int id) => await _categoryRepository.Delete(id);

    private void Validate(CategoryDTO categoryDTO)
    {
        if (categoryDTO == null)
            throw new ArgumentNullException(nameof(categoryDTO), "categoryDTO cannot be null.");

        if (categoryDTO.Name == null)
            throw new Exception("categoryDTO name is required");

        if (categoryDTO.Name.Length > 50)
            throw new Exception("categoryDTO name must be less than 50 characters");

        if (categoryDTO.Description == null)
            throw new Exception("categoryDTO description is required");

        if (categoryDTO.Description.Length > 250)
            throw new Exception("categoryDTO description must be less than 250 characters");
    }

}