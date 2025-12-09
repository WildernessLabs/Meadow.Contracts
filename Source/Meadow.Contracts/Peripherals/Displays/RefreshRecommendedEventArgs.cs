using System;

namespace Meadow.Foundation.Displays;

/// <summary>
/// Event arguments for refresh recommendation events
/// </summary>
public class RefreshRecommendedEventArgs : EventArgs
{
    /// <summary>
    /// The recommended refresh mode
    /// </summary>
    public RefreshMode RecommendedMode { get; }

    /// <summary>
    /// The current partial refresh count
    /// </summary>
    public int PartialRefreshCount { get; }

    /// <summary>
    /// The reason for the recommendation
    /// </summary>
    public string Reason { get; }

    /// <summary>
    /// Creates a new RefreshRecommendedEventArgs
    /// </summary>
    /// <param name="recommendedMode">The recommended refresh mode</param>
    /// <param name="partialRefreshCount">The current partial refresh count</param>
    /// <param name="reason">The reason for the recommendation</param>
    public RefreshRecommendedEventArgs(RefreshMode recommendedMode, int partialRefreshCount, string reason)
    {
        RecommendedMode = recommendedMode;
        PartialRefreshCount = partialRefreshCount;
        Reason = reason;
    }
}
