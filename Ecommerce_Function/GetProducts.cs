using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce_Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Ecommerce_Function
{
    public class GetProducts
    {
        private readonly DataContext _dataContext;
        
        public GetProducts(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        [FunctionName("GetProducts")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            var products = await _dataContext.Products.AsNoTracking().ToListAsync();
            var response = new ServiceResponse<List<Product>>()
            {
                Data = products
            };
            return new OkObjectResult(response);
        }
    }
}
