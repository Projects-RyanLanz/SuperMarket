using Microsoft.AspNetCore.Mvc;
using SuperMarket.DTO;
using SuperMarket.Services;

namespace SuperMarket.Controller;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase{

    private readonly ProductService _productService;

    public ProductController(ProductService productService){
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts(){
        return Ok(await _productService.GetAll());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id){
        var product = await _productService.GetById(id);
        return product == null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductDTO productDTO){
        try{
            await _productService.Create(productDTO);
            return Ok();
        }
        catch (Exception ex){
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductDTO productDTO){
        try{
            await _productService.Update(id, productDTO);
            return Ok();
        }
        catch (Exception ex){
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id){
        try{
            await _productService.Delete(id);
            return Ok();
        }
        catch (Exception ex){
            return BadRequest(ex.Message);
        }
    }

}