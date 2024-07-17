using Meadow.Hardware;
using Meadow.Units;
using System;
using System.Linq;

namespace Meadow;

/// <summary>
/// A collection of device memory-allocation statistics
/// </summary>
public struct AllocationInfo
{
    /// <summary>
    /// This is the total size of memory allocated for use by malloc in bytes. 
    /// </summary>
    public int Arena { get; set; }
    /// <summary>
    /// This is the number of free (not in use) chunks 
    /// </summary>
    public int FreeBlocks { get; set; }
    /// <summary>
    /// Size of the largest free (not in use) chunk 
    /// </summary>
    public int LargestFreeBlock { get; set; }
    /// <summary>
    /// This is the total size of memory occupied by chunks handed out by malloc. 
    /// </summary>
    public int TotalAllocated { get; set; }
    /// <summary>
    /// This is the total size of memory occupied by free (not in use) chunks.
    /// </summary>
    public int TotalFree { get; set; }
}

/// <summary>
/// Provides an abstraction for OS services such as configuration so that
/// Meadow can operate on different OS's and platforms.
/// </summary>
public partial interface IPlatformOS : IPowerController
{
    /// <summary>
    /// The command line arguments provided when the Meadow application was launched
    /// </summary>
    public string[]? LaunchArguments { get; }

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
    public INtpClient NtpClient { get; }

    /// <summary>
    /// Gets a list of currently available serial ports
    /// </summary>
    public SerialPortName[] GetSerialPortNames();

    /// <summary>
    /// Finds a platform serial port name by either friendly or system name
    /// </summary>
    /// <param name="portName"></param>
    public SerialPortName? GetSerialPortName(string portName)
    {
        return GetSerialPortNames().FirstOrDefault(
            p => string.Compare(p.FriendlyName, portName, StringComparison.OrdinalIgnoreCase) == 0
                 || string.Compare(p.SystemName, portName, StringComparison.OrdinalIgnoreCase) == 0);
    }

    /// <summary>
    /// Sets the platform OS clock
    /// </summary>
    /// <param name="dateTime"></param>
    public void SetClock(DateTime dateTime);

    /// <summary>
    /// Retrieves the current usage (as a percentage in the range of 0-100) for each processor/core
    /// </summary>
    public int[] GetProcessorUtilization();

    /// <summary>
    /// Sets the server certificate validation mode for SSL/TLS protocols
    /// </summary>
    /// <param name="authmode">The validation mode to be set: None for no validation, Optional for facultative validation,
    /// Required for mandatory validation</param>
    /// <exception cref="ArgumentException">Thrown when an invalid validation mode is provided</exception>
    /// <exception cref="Exception">Thrown when there is an error setting the validation mode</exception>
    public void SetServerCertificateValidationMode(ServerCertificateValidationMode authmode);

    /// <summary>
    /// Retrieves memory allocation statistics from the OS
    /// </summary>
    public AllocationInfo GetMemoryAllocationInfo();
}
