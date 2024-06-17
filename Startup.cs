using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PedidoAPI.Data;
using PedidoAPI.Models;
using PedidoAPI.Repositories;
using PedidoAPI.Services;
using PedidoAPI.Validations;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigin",
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

        services.AddDbContext<PedidoContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IPedidoRepository, PedidoRepository>();
        services.AddScoped<IPedidoService, PedidoService>();

        // Configurar FluentValidation
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        services.AddControllers();

        // Registrar os validadores
        services.AddValidatorsFromAssemblyContaining<Startup>();
        services.AddTransient<IValidator<ItemPedido>, ItemPedidoValidator>();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "PedidoAPI", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pedido API v1"));
        }

        app.UseCors("AllowSpecificOrigin");

        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });
    }
}
