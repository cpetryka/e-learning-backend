namespace e_learning_backend.Infrastructure.Transformers;

public class LowercaseRouteTransformer : IOutboundParameterTransformer
{
    /// <summary>
    /// Transforms the route value (controller name) into its lowercase representation.
    /// </summary>
    /// <param name="value">The route value to transform.</param>
    /// <returns>
    /// A lowercase string representation of the value if it is not null; 
    /// otherwise, returns <c>null</c>.
    /// </returns>
    public string? TransformOutbound(object? value)
    {
        return value?.ToString()?.ToLowerInvariant();
    }
}