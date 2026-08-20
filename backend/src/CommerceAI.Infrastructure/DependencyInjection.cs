using CommerceAI.Application.Products.Commands.CreateProduct;
using CommerceAI.Application.Products.Commands.DeleteProduct;
using CommerceAI.Application.Products.Commands.UpdateProduct;
using CommerceAI.Application.Products.Queries.GetProducts;
using CommerceAI.Domain.Interfaces;
using CommerceAI.Infrastructure.Persistence;
using CommerceAI.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CommerceAI.Application.Chat;

namespace CommerceAI.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(
                configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<CreateProductHandler>();
        services.AddScoped<GetProductsHandler>();
        services.AddScoped<UpdateProductHandler>();
        services.AddScoped<DeleteProductHandler>();
        services.AddScoped<ChatHandler>();

        return services;
    }
}