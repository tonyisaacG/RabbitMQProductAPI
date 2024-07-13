using Microsoft.AspNetCore.Mvc;
using ProductAPI.RabbitMQ;
using ProductAPI.Service;
using ProductAPI.Models;

namespace ProductAPI.Controller;


[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IRabitMQProducer _rabitMQProducer;
    public ProductController(IProductService productService, IRabitMQProducer rabitMQProducer)
    {
        _productService = productService;
        _rabitMQProducer = rabitMQProducer;
    }
    [HttpGet("productlist")]
    public IEnumerable<Product> ProductList()
    {
        var productList = _productService.GetProductList();
        return productList;
    }
    [HttpGet("getproductbyid")]
    public Product GetProductById(int Id)
    {
        return _productService.GetProductById(Id);
    }
    [HttpPost("addproduct")]
    public Product AddProduct(Product product)
    {
        var productData = _productService.AddProduct(product);
        _rabitMQProducer.SendProductMessage(productData);
        return productData;
    }
    [HttpPut("updateproduct")]
    public Product UpdateProduct(Product product)
    {
        return _productService.UpdateProduct(product);
    }
    [HttpDelete("deleteproduct")]
    public bool DeleteProduct(int Id)
    {
        return _productService.DeleteProduct(Id);
    }
}