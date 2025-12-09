namespace Meadow.Foundation.Displays;

/// <summary>
/// Refresh mode for displays that support multiple update strategies
/// </summary>
public enum RefreshMode
{
    /// <summary>
    /// Full refresh - complete screen update, slowest but eliminates ghosting
    /// </summary>
    Full,
    /// <summary>
    /// Fast refresh - faster update with potential slight ghosting
    /// </summary>
    Fast,
    /// <summary>
    /// Partial refresh - fastest update for small regions
    /// </summary>
    Partial
}
