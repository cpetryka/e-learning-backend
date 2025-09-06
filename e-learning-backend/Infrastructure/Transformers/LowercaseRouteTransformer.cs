namespace e_learning_backend.Infrastructure.Transformers;

public class LowercaseRouteTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        return value?.ToString()?.ToLowerInvariant();
    }
}