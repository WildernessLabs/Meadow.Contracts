using Meadow.Cloud;
using Meadow.Hardware;
using Meadow.Units;
using Meadow.Update;
using System;
using System.Linq;

namespace Meadow;

/// <summary>
/// Provides an abstraction for OS services such as configuration so that
/// Meadow can operate on different OS's and platforms.
/// </summary>
public partial interface IPlatformOS : IPowerController
{
    /// <summary>
    /// Event called when the time is changed.
    /// </summary>
    event TimeChangedEventHandler TimeChanged;

    /// <summary>
    /// The command line arguments provided when the Meadow application was launched
    /// </summary>
    string[]? LaunchArguments { get; }

    /// <summary>
    /// Initializes platform-specific OS features
    /// </summary>
    /// <param name="capabilities"></param>
    /// <param name="args">The command line arguments provided when the Meadow application was launched</param>
    void Initialize(DeviceCapabilities capabilities, string[]? args);

    /// <summary>
    /// Gets the current CPU temperature
    /// </summary>
    Temperature GetCpuTemperature();

    /// <summary>
    /// Gets the amount of storage space in use on the primary storage device
    /// </summary>
    DigitalStorage GetPrimaryDiskSpaceInUse();

    /// <summary>
    /// Gets the OS INtpClient instance
    /// </summary>
    INtpClient NtpClient { get; }

    /// <summary>
    /// Gets a list of currently available serial ports
    /// </summary>
    SerialPortName[] GetSerialPortNames();

    /// <summary>
    /// Finds a platform serial port name by either friendly or system name
    /// </summary>
    /// <param name="portName"></param>
    SerialPortName? GetSerialPortName(string portName)
    {
        return GetSerialPortNames().FirstOrDefault(
            p => string.Compare(p.FriendlyName, portName, StringComparison.OrdinalIgnoreCase) == 0
                 || string.Compare(p.SystemName, portName, StringComparison.OrdinalIgnoreCase) == 0);
    }

    /// <summary>
    /// Sets the platform OS clock
    /// </summary>
    /// <param name="dateTime"></param>
    void SetClock(DateTime dateTime);

    /// <summary>
    /// Retrieves the current usage (as a percentage in the range of 0-100) for each processor/core
    /// </summary>
    int[] GetProcessorUtilization();

    /// <summary>
    /// Sets the server certificate validation mode for SSL/TLS protocols
    /// </summary>
    /// <param name="authmode">The validation mode to be set: None for no validation, Optional for facultative validation,
    /// Required for mandatory validation</param>
    /// <exception cref="ArgumentException">Thrown when an invalid validation mode is provided</exception>
    /// <exception cref="Exception">Thrown when there is an error setting the validation mode</exception>
    void SetServerCertificateValidationMode(ServerCertificateValidationMode authmode);

    /// <summary>
    /// Retrieves memory allocation statistics from the OS
    /// </summary>
    AllocationInfo GetMemoryAllocationInfo();

    /// <summary>
    /// Retrieves an instance of the cloud connection service configured with the specified settings.
    /// </summary>
    /// <param name="settings">The settings used to configure the cloud connection service. Cannot be null.</param>
    /// <returns>An instance of <see cref="IMeadowCloudService"/> configured with the provided settings.</returns>
    IMeadowCloudService GetCloudConnectionService(IMeadowCloudSettings settings);

    /// <summary>
    /// Retrieves an instance of the cloud-based command service associated with the specified Meadow Cloud service.
    /// </summary>
    /// <param name="meadowCloudService">The Meadow Cloud service used to configure and provide access to the command service.</param>
    /// <returns>An instance of <see cref="ICommandService"/> that facilitates cloud-based command execution.</returns>
    ICommandService GetCloudCommandService(IMeadowCloudService meadowCloudService);

    /// <summary>
    /// Retrieves the current implementation of the update service.
    /// </summary>
    /// <param name="meadowCloudService">The Meadow cloud service instance.</param>
    /// <returns>An instance of <see cref="IUpdateService"/> if available; otherwise, <see langword="null"/>.</returns>
    IUpdateService GetUpdateService(IMeadowCloudService meadowCloudService);
}
