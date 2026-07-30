using CommerceAI.Application.Products.Commands.CreateProduct;
using CommerceAI.Application.Products.Queries.GetProducts;
using CommerceAI.Application.Products.Commands.UpdateProduct;
using CommerceAI.Application.Products.Commands.DeleteProduct;
namespace CommerceAI.Api.Endpoints;

public static class ProductEndpoints
{
    public static IEndpointRouteBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/products")
                       .WithTags("Products");

        group.MapPost("/", CreateProduct)
             .WithName("CreateProduct")
             .WithSummary("Creates a new product")
             .Produces<Guid>(StatusCodes.Status201Created)
             .ProducesValidationProblem();

        group.MapGet("/", GetProducts)
             .WithName("GetProducts")
             .WithSummary("Gets all products")
             .Produces<List<ProductDto>>(StatusCodes.Status200OK);

        group.MapPut("/{id:guid}", UpdateProduct)
            .WithName("UpdateProduct")
            .WithSummary("Updates an existing product")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);

        group.MapDelete("/{id:guid}", DeleteProduct)
            .WithName("DeleteProduct")
            .WithSummary("Deletes a product")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);

        return app;
    }

    private static async Task<IResult> CreateProduct(
        CreateProductCommand command,
        CreateProductHandler handler,
        CancellationToken cancellationToken)
    {
        var productId = await handler.HandleAsync(command, cancellationToken);

        return Results.Created($"/api/products/{productId}", productId);
    }

    private static async Task<IResult> GetProducts(
        GetProductsHandler handler,
        CancellationToken cancellationToken)
    {
        var products = await handler.HandleAsync(
            new GetProductsQuery(),
            cancellationToken);

        return Results.Ok(products);
    }

    private static async Task<IResult> UpdateProduct(
    Guid id,
    UpdateProductCommand command,
    UpdateProductHandler handler,
    CancellationToken cancellationToken)
    {
        var updated = await handler.HandleAsync(
            command with { Id = id },
            cancellationToken);

        return updated
            ? Results.NoContent()
            : Results.NotFound();
    }

    private static async Task<IResult> DeleteProduct(
    Guid id,
    DeleteProductHandler handler,
    CancellationToken cancellationToken)
    {
        var deleted = await handler.HandleAsync(
            new DeleteProductCommand(id),
            cancellationToken);

        return deleted
            ? Results.NoContent()
            : Results.NotFound();
    }
}