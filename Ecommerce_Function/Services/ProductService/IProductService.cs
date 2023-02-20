using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce_Model;

namespace Ecommerce_Function.Services;

public interface IProductService
{
    Task<ServiceResponse<List<Product>>> GetProductsAsync();
}