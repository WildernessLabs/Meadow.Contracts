using System;
using System.Threading.Tasks;

namespace Meadow;

/// <summary>
/// Delegate representing a time changed event handler.
/// </summary>
/// <param name="utcTime">The updated UTC time.</param>
public delegate void TimeChangedEventHandler(DateTime utcTime);

/// <summary>
/// Interface for a Network Time Protocol (NTP) client object.
/// </summary>
public interface INtpClient
{
    /// <summary>
    /// Event called when the time is changed.
    /// </summary>
    event TimeChangedEventHandler TimeChanged;

    /// <summary>
    /// Gets a value indicating whether the NTP client is enabled.
    /// </summary>
    bool Enabled { get; }

    /// <summary>
    /// Gets or sets the poll period for NTP synchronization.
    /// </summary>
    TimeSpan NtpRefreshPeriodSeconds { get; set; }

    /// <summary>
    /// Start an NTP time synchronization
    /// </summary>
    /// <param name="ntpServer">An optional NTP server address.  If null, the device will use the platform-configured NTP server address</param>
    /// <returns><b>true</b> if successful, otherwise <b>false</b></returns>
    Task<bool> Synchronize(string? ntpServer = null);

    /// <summary>
    /// Starts periodic synchronization using the configured NtpRefreshPeriodSeconds.
    /// </summary>
    public void StartPeriodicSynchronization();
}
