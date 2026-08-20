using CommerceAI.Application.Chat;

namespace CommerceAI.Api.Endpoints;

public static class ChatEndpoints
{
    public static IEndpointRouteBuilder MapChatEndpoints(
        this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/chat")
            .WithTags("Chat");

        group.MapPost("/", async (
            ChatRequest request,
            ChatHandler handler,
            CancellationToken cancellationToken) =>
        {
            var response = await handler.HandleAsync(
                request,
                cancellationToken);

            return Results.Ok(response);
        });

        return app;
    }
}