namespace Meadow.Hardware;

/// <summary>
/// Contract for devices that expose `ICanBus(es)`.
/// </summary>
public interface ICanController
{
    /// <summary>
    /// Creates a CAN bus instance for the requested bus number and bus speed
    /// </summary>
    /// <param name="busNumber">The bus number</param>
    /// <param name="bitrate">The bus bit rate</param>
    /// <returns>An instance of an <see cref="ISpiBus"/></returns>
    ICanBus CreateCanBus(CanBitrate bitrate, int busNumber);
}
