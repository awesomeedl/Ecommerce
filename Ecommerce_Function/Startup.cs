using System;
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
        builder.Services.AddDbContext<DbContext>(
            options => options.UseSqlServer(Environment.GetEnvironmentVariable(
                    "SQLAZURECONNSTR_ConnectionString") ?? throw new Exception("Sql connection string not found")));
    }
}