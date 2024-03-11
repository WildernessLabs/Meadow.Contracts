namespace Meadow.Hardware;

/// <summary>
/// Represents the configuration for a CAN bus.
/// </summary>
public interface ICanBusConfiguration
{
    /// <summary>
    /// Gets or sets a value indicating whether the bus supports Flexible Data-rate (CAN FD) frames.
    /// </summary>
    bool IsFD { get; set; }

    /// <summary>
    /// Gets or sets the bitrate of the CAN bus.
    /// </summary>
    CanBusBitrate Bitrate { get; set; }
}
