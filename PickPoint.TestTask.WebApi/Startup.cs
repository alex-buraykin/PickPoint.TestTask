using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PickPoint.TestTask.Storage.Repository;
using PickPoint.TestTask.Storage.Repository.Interfaces;
using PickPoint.TestTask.Storage.Schema;
using PickPoint.TestTask.WebApi.Controllers;

namespace PickPoint.TestTask.WebApi;

public class Startup
{
    public IConfiguration Configuration { get; }
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Setup swagger
        services.AddSwaggerGen(options =>
        {
            // add xml documentation
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "PickPoint.TestTask.WebApi.xml"));
        });
        
        // Setup database
        services.AddDbContext<IDbContext, DbContextMsSql>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IPickUpPointRepository, PickUpPointRepository>();

        services.AddControllers();
        
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
    
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "PickPoint.TestTask.WebApi");
            c.RoutePrefix = string.Empty;  // Set Swagger UI at apps root
        });
        
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}