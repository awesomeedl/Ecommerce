using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce_Function.Services;
using Ecommerce_Function.Services.ProductService;
using Ecommerce_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ecommerce_Function;

public class ProductFunctions
{
    private readonly IProductService _productService;

    public ProductFunctions(IProductService productService)
    {
        _productService = productService;
    }

    [FunctionName("GetProducts")]
    public async Task<IActionResult> GetProducts(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "product")] 
        HttpRequest req,
        ILogger log)
    {
        var result = await _productService.GetProductsAsync();
        return result is not null ? new OkObjectResult(result) : new NotFoundResult();
    }
    
    [FunctionName("GetProduct")]
    public async Task<IActionResult> GetProduct(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "product/{id:int}")] 
        HttpRequest req, 
        int id, 
        ILogger log)
    {
        var result = await _productService.GetProductAsync(id);

        return result is not null ? new OkObjectResult(result) : new NotFoundObjectResult(new Product { Id = id });
    }
}