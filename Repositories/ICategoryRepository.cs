using SuperMarket.DTO;
using SuperMarket.Models;

namespace SuperMarket.Repositories;

public interface ICategoryRepository{
    Task<IEnumerable<Category>> GetAll();
    Task<Category?> GetById(int id);
    Task Create(CategoryDTO category);
    Task Update(int id, CategoryDTO category);
    Task Delete(int id);
}