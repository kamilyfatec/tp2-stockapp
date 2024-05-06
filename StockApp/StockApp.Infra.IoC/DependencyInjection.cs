using HelperStockBeta.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockApp.Domain.Interfaces;
using StockApp.Infra.Data.Context;
using StockApp.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StockApp.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection sevices, IConfiguration configuration)
        {
            sevices.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
            ), b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            sevices.AddScoped<ICategoryRepository, CategoryRepository>();
            sevices.AddScoped<IProductRepository, ProductRepository>();
            return sevices;
        }
    }
}