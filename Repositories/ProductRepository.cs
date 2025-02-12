using Microsoft.EntityFrameworkCore;
using SuperMarket.DTO;
using SuperMarket.Models; 

namespace SuperMarket.Repositories;

public class ProductRepository : IProductRepository
{

    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context){
        _context = context;
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<Product?> GetById(int id)
    { 
        return await _context.Products.FindAsync(id);
    }

    public async Task Create(ProductDTO productDTO)
    { 
        var category = await _context.Categories.FindAsync(productDTO.CategoryId);
        if(category == null){
            throw new Exception("Category not found");
        }
        var  product = new Product{
            Name = productDTO.Name, 
            Price = productDTO.Price,
            CategoryId = productDTO.CategoryId,
            Category = category
        };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

    }

    public async Task Update(int id,ProductDTO productDTO)
    {
         
        var  product =  await GetById(id);
        if(product == null){
            throw new Exception("Product not found");
        }else{
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
        
    }
    public async Task Delete(int id)
    {
        var product = await GetById(id);
        if(product != null){
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }else{
            throw new Exception("Product not found");
        }
    }
}