namespace Meadow.Cloud;

/// <summary>
/// An abstraction for connection settings for the Meadow.Cloud service
/// </summary>
public interface IMeadowCloudSettings
{
    /// <summary>
    /// The host name to use for authentication
    /// </summary>
    string AuthHostname { get; set; }
    /// <summary>
    /// The host name used for data exchange
    /// </summary>
    string DataHostname { get; set; }
    /// <summary>
    /// Enable to send health metrics to Meadow.Cloud
    /// </summary>
    bool EnableHealthMetrics { get; set; }
    /// <summary>
    /// Interval (in minutes) to send health metrics
    /// </summary>
    int HealthMetricsIntervalMinutes { get; set; }
    /// <summary>
    /// Enable to provide update service capabiltiies
    /// </summary>
    bool EnableUpdates { get; set; }
    /// <summary>
    /// The host name used for cloud MQTT subscriptions
    /// </summary>
    string MqttHostname { get; set; }
    /// <summary>
    /// The port used for cloud MQTT subscriptions
    /// </summary>
    int MqttPort { get; set; }
    /// <summary>
    /// Reconnect period used when a disconnection from the server occurs
    /// </summary>
    int ConnectRetrySeconds { get; set; }
    /// <summary>
    /// Timeout period used when a authenticating
    /// </summary>
    int AuthTimeoutSeconds { get; set; }
    /// <summary>
    /// Whether or not authentication is used with the cloud server
    /// </summary>
    bool UseAuthentication { get; set; }
    /// <summary>
    /// Whether or not Meadow.Cloud services are enabled
    /// </summary>
    bool Enabled { get; set; }
    /// <summary>
    /// The maximum number of events to queue for cloud delivery before discarding the oldest records
    /// </summary>
    int MaxQueueDepth { get; set; }
}