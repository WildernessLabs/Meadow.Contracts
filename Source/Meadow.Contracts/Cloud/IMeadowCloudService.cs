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
    /// Occurs when a message is successfully sent.
    /// </summary>
    /// <remarks>Subscribe to this event to be notified whenever a message is sent. The event handler receives
    /// an <see cref="EventArgs"/> object, which does not contain additional data for this event.</remarks>
    event EventHandler? MessageSent;

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
    /// <param name="throwIfDisabled">Throws an exception if the service is not currently enabled</param>
    /// <param name="priority">The priority level for the log event</param>
    Task SendLog(CloudLog cloudLog, CloudTelemetryPriority priority = CloudTelemetryPriority.Normal, bool throwIfDisabled = true);

    /// <summary>
    /// Sends a CloudEvent to the Meadow.Cloud service
    /// </summary>
    /// <param name="cloudEvent"></param>
    /// <param name="throwIfDisabled">Throws an exception if the service is not currently enabled</param>
    Task SendEvent(CloudEvent cloudEvent, bool throwIfDisabled = true);

    /// <summary>
    /// Sends a CloudEvent to the Meadow.Cloud service
    /// </summary>
    /// <param name="eventId">id used for a set of events.</param>
    /// <param name="description">Description of the event.</param>
    /// <param name="measurements">Dynamic payload of measurements to be recorded.</param>
    Task SendEvent(int eventId, string description, Dictionary<string, object> measurements)
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
    /// <param name="priority">The priority level for the log event</param>
    Task SendLog(string logLevel, string message, string? exceptionMessage = null, CloudTelemetryPriority priority = CloudTelemetryPriority.Normal)
    {
        return SendLog(new CloudLog()
        {
            Severity = logLevel,
            Message = message,
            Timestamp = DateTime.UtcNow,
            Exception = exceptionMessage ?? string.Empty
        }, priority);
    }

    /// <summary>
    /// Stops the service
    /// </summary>
    void Stop();
}