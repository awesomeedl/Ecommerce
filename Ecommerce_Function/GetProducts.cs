using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce_Function.Services;
using Ecommerce_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ecommerce_Function;

public class GetProducts
{
    private readonly IProductService _productService;

    public GetProducts(IProductService productService)
    {
        _productService = productService;
    }

    [FunctionName("GetProducts")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
        HttpRequest req,
        ILogger log)
    {
        var result = await _productService.GetProductsAsync();
        return new OkObjectResult(result);
    }
}