namespace Meadow.Hardware;

/// <summary>
/// Abstraction for Counter devices
/// </summary>
public interface ICounter
{
    /// <summary>
    /// Gets or sets the Enabled property
    /// </summary>
    bool Enabled { get; set; }
    /// <summary>
    /// Gets the current Count
    /// </summary>
    ulong Count { get; }
    /// <summary>
    /// Resets the Count to zero
    /// </summary>
    void Reset();
}