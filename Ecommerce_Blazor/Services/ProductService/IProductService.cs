using Ecommerce_Model;

namespace Ecommerce_Blazor.Services.ProductService;

public interface IProductService
{
    List<Product> Products { get; set; }
    Task GetProducts();
    Task<ServiceResponse<Product>> GetProduct(int productId);
}