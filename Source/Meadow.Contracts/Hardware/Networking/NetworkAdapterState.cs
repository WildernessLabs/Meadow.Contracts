namespace Meadow.Hardware;

/// <summary>
/// Represents the current state of a network adapter.
/// </summary>
public enum NetworkAdapterState
{
    /// <summary>
    /// The network adapter state cannot be determined.
    /// </summary>
    Unknown,

    /// <summary>
    /// The network adapter is not connected to any network.
    /// </summary>
    Disconnected,

    /// <summary>
    /// The network adapter is in the process of establishing a connection.
    /// </summary>
    Connecting,

    /// <summary>
    /// The network adapter is successfully connected to a network.
    /// </summary>
    Connected,

    /// <summary>
    /// The network adapter is in the process of terminating its connection.
    /// </summary>
    Disconnecting,

    /// <summary>
    /// The network adapter encountered an error while attempting to connect.
    /// </summary>
    ConnectionError,

    /// <summary>
    /// The network adapter encountered an error during initialization.
    /// </summary>
    InitializationError
}
