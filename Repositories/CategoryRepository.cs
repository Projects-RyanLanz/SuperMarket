using Microsoft.EntityFrameworkCore;
using SuperMarket.DTO;
using SuperMarket.Models;

namespace SuperMarket.Repositories;

public class CategoryRepository : ICategoryRepository{

    private readonly AppDbContext _context;

    public CategoryRepository(AppDbContext context){
        _context = context;
    }
    public async Task<IEnumerable<Category>> GetAll()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> GetById(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task Create(CategoryDTO categoryDTO)
    {
        var category = new Category{
            Name = categoryDTO.Name,
            Description = categoryDTO.Description
        };
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
    }
    public async Task Update(int id, CategoryDTO categoryDTO)
    {
        var category = await GetById(id);
        if (category != null)
        {
            category.Name = categoryDTO.Name;
            category.Description = categoryDTO.Description;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }else{
            throw new Exception("Category not found");
        }
    }

    public async Task Delete(int id)
    {
        var category = await GetById(id);
        if(category != null){
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync(); 
        }else{
            throw new Exception("Category not found");
        }
    }
 
}