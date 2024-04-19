using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Skinet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly StoreContext _context;
    
    public ProductsController(StoreContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var products = await _context.Products.ToListAsync();
        return products;
    }
    
    
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Product>> GetProductsByIdAsync(int id)
    {
        if (id != null)
        {
            var product = await _context.Products.FirstAsync(x => x.Id == id);
            return product;  
        }

        return NotFound();
    }

    [HttpPut]
    public string UpdateProduct(int id)
    {
        // Add Put method
        return null;
    }

    [HttpDelete]
    [Route("{id:int}")]
    public IActionResult DeleteProduct(int id)
    {
        Product obj = _context.Products.First(x => x.Id == id);
        _context.Products.Remove(obj);
        _context.SaveChangesAsync();
        return Ok();
    }
    
    [HttpPost]
    public IActionResult CreateProduct(Product product)
    {
        // insert POST method
        return null;
    }
}