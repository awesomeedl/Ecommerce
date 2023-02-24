using System;
using System.Diagnostics;
using Ecommerce_Function;
using Ecommerce_Function.Services;
using Ecommerce_Function.Services.ProductService;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Ecommerce_Function;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddSqlite<DataContext>("Data Source=Products.db");
        builder.Services.AddScoped<IProductService, ProductService>();
    }
}