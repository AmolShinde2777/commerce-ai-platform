namespace CommerceAI.Application.Chat;

public sealed class ChatHandler
{
    public Task<ChatResponse> HandleAsync(
        ChatRequest request,
        CancellationToken cancellationToken)
    {
        var response =
            $"I received your message: \"{request.Message}\". " +
            "AI product search will be connected next.";

        return Task.FromResult(
            new ChatResponse(response));
    }
}