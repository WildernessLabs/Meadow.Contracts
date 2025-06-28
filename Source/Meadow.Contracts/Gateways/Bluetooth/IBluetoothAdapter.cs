using Meadow.Gateways.Bluetooth;
using System;

namespace Meadow.Gateways;

/// <summary>
/// Represents a Bluetooth adapter.
/// </summary>
public interface IBluetoothAdapter
{
    /// <summary>
    /// Occurs when the Bluetooth server is beginning to start.
    /// </summary>
    event EventHandler? ServerStarting;

    /// <summary>
    /// Occurs when the Bluetooth server has successfully started and is ready to accept connections.
    /// </summary>
    event EventHandler? ServerStarted;

    /// <summary>
    /// Occurs when the Bluetooth server is beginning to stop.
    /// </summary>
    event EventHandler? ServerStopping;

    /// <summary>
    /// Occurs when the Bluetooth server has successfully stopped.
    /// </summary>
    event EventHandler? ServerStopped;

    /// <summary>
    /// Occurs when a client has successfully connected to the Bluetooth server.
    /// </summary>
    event EventHandler? ClientConnected;

    /// <summary>
    /// Occurs when a client has disconnected from the Bluetooth server.
    /// </summary>
    event EventHandler? ClientDisconnected;

    /// <summary>
    /// Starts the Bluetooth server with the specified configuration.
    /// </summary>
    /// <param name="configuration">The Bluetooth definition configuration.</param>
    /// <returns><c>true</c> if the Bluetooth server is successfully started; otherwise, <c>false</c>.</returns>
    bool StartBluetoothServer(IDefinition configuration);

    /// <summary>
    /// Stop the Bluetooth server.
    /// </summary>
    /// <returns><c>true</c> if the Bluetooth server is successfully stopped; otherwise, <c>false</c>.</returns> 
    bool StopBluetoothServer();
}