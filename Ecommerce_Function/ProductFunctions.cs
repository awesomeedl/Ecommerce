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
    public async Task<IActionResult> Run1(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "product")]
        HttpRequest req,
        ILogger log)
    {
        var result = await _productService.GetProductsAsync();
        return new OkObjectResult(result);
    }
    
    [FunctionName("GetProduct")]
    public async Task<IActionResult> Run2(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "product/{id:int}")] HttpRequest req, int id, ILogger log)
    {
        var result = await _productService.GetProductAsync(id);
        return new OkObjectResult(result);
    }
}