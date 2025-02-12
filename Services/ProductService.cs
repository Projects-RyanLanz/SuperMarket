using SuperMarket.DTO;
using SuperMarket.Models;
using SuperMarket.Repositories;

namespace SuperMarket.Services;

public class ProductService {

    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public  ProductService(IProductRepository productRepository,ICategoryRepository categoryRepository){
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Product>> GetAll() => await _productRepository.GetAll();

    public async Task<Product?> GetById(int id) => await _productRepository.GetById(id);

    public async Task Create(ProductDTO productDTO) {
        Validate(productDTO);
        await _productRepository.Create(productDTO);
    }

    public async Task Update(int id,ProductDTO productDTO){
        Validate(productDTO);
        await _productRepository.Update(id,productDTO);
    }

    public async Task Delete(int id) => await _productRepository.Delete(id);


    private void Validate(ProductDTO productDTO){
        if (productDTO == null)
            throw new ArgumentNullException(nameof(productDTO), "productDTO cannot be null.");

        if (productDTO.Name == null)
            throw new Exception("productDTO name is required");

        if (productDTO.Name.Length >= 100)
            throw new Exception("productDTO name must be less than 50 characters");

        if (productDTO.Price <= 0)
            throw new Exception("productDTO price is required");

        var category = _categoryRepository.GetById(productDTO.CategoryId);
        if(category == null){
            throw new Exception("Category not found");
        } 
    }

}