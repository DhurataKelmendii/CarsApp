using Cars.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars.Infrastructure.Extension
{
    public static class ConfigureContainerService
    {
        public static void AddDbContext(this IServiceCollection serviceCollection,
      IConfiguration configuration, IConfigurationRoot configRoot)
        {
            serviceCollection.AddDbContext<CarsDbContext>(options =>
                   options.UseSqlServer(configuration.GetConnectionString("CarsDbConn") ?? configRoot["ConnectionStrings:CarsDbConn"]
                , b => b.MigrationsAssembly(typeof(CarsDbContext).Assembly.FullName)));


        }
    }
}
