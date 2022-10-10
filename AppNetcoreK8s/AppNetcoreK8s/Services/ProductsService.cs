using AppNetcoreK8s.Models;
using AppNetcoreK8s.Repository.interfaces;
using Microsoft.AspNetCore.Authorization;

namespace AppNetcoreK8s.Services;

internal static class ProductsService
{
    public static IServiceCollection
        AddProductService(this IServiceCollection services, IConfiguration configuration) => services;

    public static WebApplication MapProductsService(this WebApplication app){
        app.MapPost("/products-list",
             async (HttpContext context, IProductRepository productRepository) => {
                var response = await productRepository.GetProductsAsync();

                return Results.Ok(response);
            });

        return app;
    }
}