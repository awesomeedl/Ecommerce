using System;
using System.Diagnostics;
using System.Reflection;
using Microsoft.Azure.Functions.Extensions;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(Ecommerce_Function.Startup))]

namespace Ecommerce_Function;

public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var connectionStr = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_ConnectionString");
        Debug.Assert(!string.IsNullOrEmpty(connectionStr), "Connection string not found");
        builder.Services.AddDbContext<DataContext>(
            options => options.UseSqlServer(connectionStr));
    }
}