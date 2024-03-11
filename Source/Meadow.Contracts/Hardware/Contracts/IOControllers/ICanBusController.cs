namespace Meadow.Hardware;

/// <summary>
/// Contract for devices that expose CAN (controller area network) buses
/// </summary>
public interface ICanController
{
    /// <summary>
    /// Creates a CAn bus
    /// </summary>
    /// <returns></returns>
    public ICanBus CreateCanBus(ICanBusConfiguration configuration);
}
