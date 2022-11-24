 using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

using Venta.AppServices;
using Venta.AppServices.Interfaces;
using Venta.Infraestructure.Context;
using Venta.Infraestructure.Interface;
using Venta.Infraestructure.Repository;

//using VentasApp.Api.Infraestructure.Context;
//using VentasApp.Api.Infraestructure.Data.Repository;
//using VentasApp.Api.Infraestructure.Data.Repository.Constract;
//using VentasApp.Api.Service;
//using VentasApp.Api.Service.Contract;

namespace VentasApp.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
           // services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VentasApp.Api", Version = "v1" });
            });

            services.AddCors();


            // JsonSerialization
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            services.AddDbContext<VentaContext>(options => options.UseSqlServer(this.Configuration.GetConnectionString("Prueba")));

            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddTransient<ICategoryService, CategoryService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddTransient<IProductService, ProductService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "VentasApp.Api v1"));
            }

            app.UseRouting();


            // Enable Cors
            app.UseCors(co => co
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .SetIsOriginAllowed(origin => true)  );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                 
            });




        }
    }
}
