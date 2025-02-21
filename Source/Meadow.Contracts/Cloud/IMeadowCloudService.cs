using Meadow.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meadow.Cloud;

/// <summary>
/// An abstraction for the Meadow.Cloud service
/// </summary>
public interface IMeadowCloudService
{
    /// <summary>
    /// Event raised when an error in communicating with Meadow Cloud occurrs
    /// </summary>
    event EventHandler<Exception>? ErrorOccurred;

    /// <summary>
    /// Event raised when the cloud connection state changes
    /// </summary>
    event EventHandler<CloudConnectionState>? ConnectionStateChanged;

    /// <summary>
    /// Gets the Enabled state for the service
    /// </summary>
    bool IsEnabled { get; }

    /// <summary>
    /// Gets the current connection state for the service
    /// </summary>
    CloudConnectionState ConnectionState { get; }

    /// <summary>
    /// Gets the current number of items to be sent.
    /// </summary>
    int QueueCount { get; }

    /// <summary>
    /// Sends a log message to the Meadow.Cloud service
    /// </summary>
    /// <param name="cloudLog">The log entry to send</param>
    Task SendLog(CloudLog cloudLog);

    /// <summary>
    /// Sends a CloudEvent to the Meadow.Cloud service
    /// </summary>
    /// <param name="cloudEvent"></param>
    Task SendEvent(CloudEvent cloudEvent);

    /// <summary>
    /// Sends a CloudEvent to the Meadow.Cloud service
    /// </summary>
    /// <param name="eventId">id used for a set of events.</param>
    /// <param name="description">Description of the event.</param>
    /// <param name="measurements">Dynamic payload of measurements to be recorded.</param>
    public Task SendEvent(int eventId, string description, Dictionary<string, object> measurements)
    {
        return SendEvent(new CloudEvent()
        {
            EventId = eventId,
            Description = description,
            Measurements = measurements,
            Timestamp = DateTime.UtcNow
        });
    }

    /// <summary>
    /// Sends a log message to the Meadow.Cloud service
    /// </summary>
    /// <param name="level">The log level for the log event</param>
    /// <param name="message">The message property for the log event</param>
    Task SendLog(LogLevel level, string message)
    {
        return SendLog(level.ToString(), message);
    }

    /// <summary>
    /// Sends a log message to the Meadow.Cloud service
    /// </summary>
    /// <param name="logLevel">The log level for the log event</param>
    /// <param name="message">The message property for the log event</param>
    /// <param name="exceptionMessage">Optional exception message data</param>
    Task SendLog(string logLevel, string message, string? exceptionMessage = null)
    {
        return SendLog(new CloudLog()
        {
            Severity = logLevel,
            Message = message,
            Timestamp = DateTime.UtcNow,
            Exception = exceptionMessage ?? string.Empty
        });
    }

    /// <summary>
    /// Stops the service
    /// </summary>
    public void Stop();
}