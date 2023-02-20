using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce_Model;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Function.Services;

public class ProductService : IProductService
{
    private readonly DataContext _dataContext;
    
    public ProductService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
    {
        var response = new ServiceResponse<List<Product>>
        {
            Data = await _dataContext.Products.ToListAsync()
        };

        return response;
    }
}