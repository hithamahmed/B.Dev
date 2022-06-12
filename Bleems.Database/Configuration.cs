using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bleems.Database
{
    public static class Configuration
    {
        public static IServiceCollection SqlDataBase(this IServiceCollection services,string connection)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(connection,
                sqlServerOptionsAction: option =>
                {
                    option.EnableRetryOnFailure(maxRetryCount: 5,maxRetryDelay: TimeSpan.FromSeconds(30),errorNumbersToAdd: null);
                });
            });

            services.AddScoped<DataContext>();
            services.AddTransient<IProductsRepo,ProductsQuery>();
            services.AddTransient<ICategoryRepo,CategoryRepo>();

            return services;
        }
            
    }
}
