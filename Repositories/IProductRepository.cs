using SuperMarket.DTO;
using SuperMarket.Models;

namespace SuperMarket.Repositories;

public interface  IProductRepository{
    Task<IEnumerable<Product>> GetAll();
    Task<Product?> GetById(int id);
    Task Create(ProductDTO productDTO);
    Task Update(int id,ProductDTO productDTO);
    Task Delete(int id);
}