using System.Net.Http.Json;
using Ecommerce_Model;
namespace Ecommerce_Blazor.Services.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    private readonly string _baseApiUrl;

    public ProductService(HttpClient httpClient, IConfiguration configuration)
    {
        _baseApiUrl = configuration[_baseApiUrl];
        _httpClient = httpClient;
    }
    
    public List<Product> Products { get; set; } = new List<Product>();
    
    public async Task GetProducts()
    {
        var result = await _httpClient.GetFromJsonAsync<ServiceResponse<List<Product>>>(_baseApiUrl);
        if (result is { Data: { } })
        {
            Products = result.Data;
        }
    }

    public async Task<ServiceResponse<Product>> GetProduct(int productId)
    {
        return await _httpClient.GetFromJsonAsync<ServiceResponse<Product>>($"{_baseApiUrl}/{productId}");
    }
}