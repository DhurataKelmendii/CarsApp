using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Cars.Infrastructure.Extension;
using Cars.Persistence;
using System;
using System.IO;
using Cars.Persistence.Repositories;

namespace Cars.API
{
    public class Startup
    {
        private readonly IConfigurationRoot configRoot;


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //dh
            //IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            //configRoot = builder.Build();
            //dh/
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddDbContext<CarsDbContext>
           (o => o.UseSqlServer(Configuration.
            GetConnectionString("CarsDbConn")));

            services.AddControllers();

            //dh
            services.AddRazorPages();
            services.AddMvc();
            services.AddHttpContextAccessor();
            //services.AddTransient(IRepository<>, Repository<>);


            //services.AddTransient(typeof(IRepository<>), typeof(Repository<>));


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cars.API", Version = "v1" });
            });

            ////dh
            //services.AddDbContext<CarsDbContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("CarsDbConn")));

            //services.AddScoped<ICarsDbContext, CarsDbContext>();

            //var assembly = AppDomain.CurrentDomain.Load("Cars.Service");

            //services.AddMediatR(assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cars.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
