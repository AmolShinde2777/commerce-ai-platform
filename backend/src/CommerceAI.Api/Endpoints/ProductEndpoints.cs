using CommerceAI.Application.Products.Commands.CreateProduct;

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
}