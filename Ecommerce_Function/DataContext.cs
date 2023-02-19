using System;
using System.Diagnostics;
using Ecommerce_Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Ecommerce_Function;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}
    
    public DbSet<Product> Products { get; set; }
}

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
        var constr = Environment.GetEnvironmentVariable("SQLAZURECONNSTR_ConnectionString");
        Debug.Assert(!string.IsNullOrEmpty(constr));
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer(constr);

        return new DataContext(optionsBuilder.Options);
    }
}