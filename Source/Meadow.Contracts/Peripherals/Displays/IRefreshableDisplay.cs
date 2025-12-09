using System;

namespace Meadow.Foundation.Displays;

/// <summary>
/// Interface for displays that support multiple refresh modes (full, fast, partial)
/// </summary>
public interface IRefreshableDisplay
{
    /// <summary>
    /// Current refresh mode
    /// </summary>
    RefreshMode CurrentRefreshMode { get; set; }

    /// <summary>
    /// Number of partial refreshes performed since last full refresh
    /// </summary>
    int PartialRefreshCount { get; }

    /// <summary>
    /// Maximum recommended partial refreshes before full refresh
    /// </summary>
    int MaxPartialRefreshes { get; set; }

    /// <summary>
    /// Indicates whether a full refresh is recommended
    /// </summary>
    bool IsFullRefreshRecommended { get; }

    /// <summary>
    /// Event raised when a fast refresh is recommended
    /// </summary>
    event EventHandler<RefreshRecommendedEventArgs>? FastRefreshRecommended;

    /// <summary>
    /// Event raised when a full refresh is recommended
    /// </summary>
    event EventHandler<RefreshRecommendedEventArgs>? FullRefreshRecommended;

    /// <summary>
    /// Display buffer using full refresh mode
    /// </summary>
    void ShowFull();

    /// <summary>
    /// Display buffer using fast refresh mode
    /// </summary>
    void ShowFast();

    /// <summary>
    /// Display region using partial refresh mode
    /// </summary>
    /// <param name="left">left bounds of region in pixels</param>
    /// <param name="top">top bounds of region in pixels</param>
    /// <param name="right">right bounds of region in pixels</param>
    /// <param name="bottom">bottom bounds of region in pixels</param>
    void ShowPartial(int left, int top, int right, int bottom);

    /// <summary>
    /// Reset the partial refresh counter
    /// </summary>
    void ResetPartialRefreshCount();
}
