﻿using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Skinet.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductRepository _repository;


    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetProducts()
    {
        var products = await _repository.GetProductsAsync();
        return Ok(products);
    }
    
    
    
    [HttpGet]
    [Route("{id:int}")]
    public async Task<ActionResult<Product>> GetProductsByIdAsync(int id)
    {
        if (id != null)
        {
            return await _repository.GetProductByIdAsync(id); 
        }

        return NotFound();
    }

    [HttpGet]
    [Route("brands")]
    public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
    {
        return Ok(await _repository.GetProductBrandsAsync());
    }

    [HttpGet]
    [Route("types")]
    public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
    {
        return Ok(await _repository.GetProductTypesAsync());
    }



    /*[HttpPut]
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
    }*/
}