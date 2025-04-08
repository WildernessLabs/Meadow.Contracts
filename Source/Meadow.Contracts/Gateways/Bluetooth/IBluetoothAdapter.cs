using Meadow.Gateways.Bluetooth;

namespace Meadow.Gateways
{
    /// <summary>
    /// Represents a Bluetooth adapter.
    /// </summary>
    public interface IBluetoothAdapter
    {
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
}