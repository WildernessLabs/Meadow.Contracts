using System;

namespace Meadow.Hardware;

/// <summary>
/// Reasons a platform might have been reset
/// </summary>
[Flags]
public enum ResetReason
{
    /// <summary>
    /// The reset reason is not determined
    /// </summary>
    Unknown = 0,
    /// <summary>
    /// Power was too low to maintain operation (brown out)
    /// </summary>
    InsufficientPower = 1 << 1,
    /// <summary>
    /// Reset pin/interrupt detected
    /// </summary>
    HardwareReset = 1 << 2,
    /// <summary>
    /// Normal power-on reset
    /// </summary>
    PowerOnReset = 1 << 3,
    /// <summary>
    /// Software-triggered reset
    /// </summary>
    SoftwareReset = 1 << 4,
    /// <summary>
    /// An independent watchdog timer expired
    /// </summary>
    IndependentWatchdog = 1 << 5,
    /// <summary>
    /// An window watchdog timer expired
    /// </summary>
    WindowWatchdog = 1 << 6,
    /// <summary>
    /// A reset due to low power
    /// </summary>
    LowPower = 1 << 7
}

