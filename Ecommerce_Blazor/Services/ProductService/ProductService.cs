using System.Net.Http.Json;
using Ecommerce_Model;
namespace Ecommerce_Blazor.Services.ProductService;

public class ProductService : IProductService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly string _baseApiUrl;

    public ProductService(HttpClient httpClient, IConfiguration configuration)
    {
        _configuration = configuration;
        _httpClient = httpClient;
    }
    
    public List<Product> Products { get; set; } = new List<Product>();
    
    public async Task GetProducts()
    {
        Console.WriteLine($"url: {_configuration.GetValue<string>("LocalAPIUrl")}");
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