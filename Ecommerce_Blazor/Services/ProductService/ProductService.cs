using System.Net.Http.Json;
using Ecommerce_Model;

namespace Ecommerce_Blazor.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public List<Product> Products { get; set; } = new List<Product>();
    
    public async Task GetProducts()
    {
        var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>("https://ecommercefunction.azurewebsites.net/api/product/");
        if (result is { Data: { } })
        {
            Products = result.Data;
        }
    }

    public async Task<ServiceResponse<Product>> GetProduct(int productId)
    {
        return await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"https://ecommercefunction.azurewebsites.net/api/{productId}/");
    }
}