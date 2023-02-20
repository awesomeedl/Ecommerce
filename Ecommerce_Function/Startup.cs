using System;
using System.Diagnostics;
using Ecommerce_Function;
using Ecommerce_Function.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Startup))]

namespace Ecommerce_Function;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var connectionStr = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_ConnectionString");
        Debug.Assert(!string.IsNullOrEmpty(connectionStr), "Connection string not found");
        builder.Services.AddDbContext<DataContext>(
            options => options.UseSqlServer(connectionStr));
        builder.Services.AddScoped<IProductService, ProductService>();
    }
}