using Meadow.Hardware;

namespace Meadow;

/// <summary>
/// Contract for Meadow boards.
/// </summary>
public interface IMeadowDevice :
    IDigitalInputOutputController,
    IDigitalInterruptController,
    IBiDirectionalController,
    IAnalogInputController,
    IPwmOutputController,
    ISerialController,
    ISerialMessageController,
    ISpiController,
    II2cController,
    IWatchdogController,
    ICounterController,
    INetworkAdapterController
{
    /// <summary>
    /// Retrieves an IPin from the device by string
    /// </summary>
    /// <param name="name">Either the string Name or Key or the IPin</param>
    /// <returns></returns>
    IPin GetPin(string name);

    /// <summary>
    /// Retrieves OS-Specific implementations for the IMeadowDevice
    /// </summary>
    IPlatformOS PlatformOS { get; }

    /// <summary>
    /// Retrieves the IDeviceInformation for the current IMeadowDevice
    /// </summary>
    IDeviceInformation Information { get; }

    /// <summary>
    /// Gets the device capabilities.
    /// </summary>
    DeviceCapabilities Capabilities { get; }

    /// <summary>
    /// Method called by the Core stack to initialize the IMeadowDevice
    /// </summary>
    /// <param name="detectedPlatform">The MeadowPlatform that core detected the application is running on</param>
    void Initialize(MeadowPlatform detectedPlatform);

    /// <summary>
    /// Retrieves battery info about the current IMeadowDevice
    /// </summary>
    /// <returns></returns>
    BatteryInfo? GetBatteryInfo();

    /// <summary>
    /// Gets a device-specific instance if an IReliabilityService interface
    /// </summary>
    public IReliabilityService? ReliabilityService { get => null; }
}
