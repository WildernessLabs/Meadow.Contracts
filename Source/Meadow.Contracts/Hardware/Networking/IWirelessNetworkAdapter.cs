﻿using Meadow.Gateway.WiFi;
using Meadow.Gateways;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Meadow.Hardware
{
    public interface IWirelessNetworkAdapter : INetworkAdapter
    {
        /// <summary>
        /// Access point the adapter is currently connected to
        /// </summary>
        string? Ssid { get; }

        /// <summary>
        /// Start a WiFi network.
        /// </summary>
        /// <param name="ssid">Name of the network to connect to.</param>
        /// <param name="password">Password for the network.</param>
        /// <param name="timeout">Timeout period for the connection attempt</param>
        /// <param name="token">Cancellation token for the connection attempt</param>
        /// <param name="reconnection">Should the adapter reconnect automatically?</param>
        /// <exception cref="ArgumentNullException">Thrown if the ssid is null or empty or the password is null.</exception>
        /// <returns>true if the connection was successfully made.</returns>
        Task<ConnectionResult> Connect(string ssid, string password, TimeSpan timeout, CancellationToken token, ReconnectionType reconnection = ReconnectionType.Automatic);

        /// <summary>
        /// Start a WiFi network.
        /// </summary>
        /// <param name="ssid">Name of the network to connect to.</param>
        /// <param name="password">Password for the network.</param>
        /// <param name="reconnection">Should the adapter reconnect automatically?</param>
        /// <exception cref="ArgumentNullException">Thrown if the ssid is null or empty or the password is null.</exception>
        /// <returns>true if the connection was successfully made.</returns>
        async Task<ConnectionResult> Connect(string ssid, string password, ReconnectionType reconnection = ReconnectionType.Automatic)
        {
            var src = new CancellationTokenSource();
            return await Connect(ssid, password, TimeSpan.Zero, src.Token, reconnection);
        }

        /// <summary>
        /// Start a WiFi network.
        /// </summary>
        /// <param name="ssid">Name of the network to connect to.</param>
        /// <param name="password">Password for the network.</param>
        /// <param name="token">Cancellation token for the connection attempt</param>
        /// <param name="reconnection">Should the adapter reconnect automatically?</param>
        /// <exception cref="ArgumentNullException">Thrown if the ssid is null or empty or the password is null.</exception>
        /// <returns>true if the connection was successfully made.</returns>
        async Task<ConnectionResult> Connect(string ssid, string password, CancellationToken token, ReconnectionType reconnection = ReconnectionType.Automatic)
        {
            var src = new CancellationTokenSource();
            return await Connect(ssid, password, TimeSpan.Zero, token, reconnection);
        }

        /// <summary>
        /// Start a WiFi network.
        /// </summary>
        /// <param name="ssid">Name of the network to connect to.</param>
        /// <param name="password">Password for the network.</param>
        /// <param name="timeout">Timeout period for the connection attempt</param>
        /// <param name="reconnection">Should the adapter reconnect automatically?</param>
        /// <exception cref="ArgumentNullException">Thrown if the ssid is null or empty or the password is null.</exception>
        /// <returns>true if the connection was successfully made.</returns>
        async Task<ConnectionResult> Connect(string ssid, string password, TimeSpan timeout, ReconnectionType reconnection = ReconnectionType.Automatic)
        {
            var src = new CancellationTokenSource();
            return await Connect(ssid, password, timeout, src.Token, reconnection);
        }

        /// <summary>
        /// Start a WiFi network.
        /// </summary>
        /// <param name="ssid">Name of the network to connect to.</param>
        /// <param name="password">Password for the network.</param>
        /// <param name="timeout">Timeout period for the connection attempt</param>
        /// <param name="token">Cancellation token for the connection attempt</param>
        /// <returns>true if the connection was successfully made.</returns>
        async Task<ConnectionResult> Connect(string ssid, string password, TimeSpan timeout, CancellationToken token)
        {
            var src = new CancellationTokenSource();
            return await Connect(ssid, password, TimeSpan.Zero, token, ReconnectionType.Automatic);
        }

        /// <summary>
        /// Start a WiFi network.
        /// </summary>
        /// <param name="ssid">Name of the network to connect to.</param>
        /// <param name="password">Password for the network.</param>
        /// <param name="timeout">Timeout period for the connection attempt</param>
        /// <returns>true if the connection was successfully made.</returns>
        async Task<ConnectionResult> Connect(string ssid, string password, TimeSpan timeout)
        {
            return await Connect(ssid, password, timeout, CancellationToken.None);
        }

        /// <summary>
        /// Start a WiFi network.
        /// </summary>
        /// <param name="ssid">Name of the network to connect to.</param>
        /// <param name="password">Password for the network.</param>
        /// <returns>true if the connection was successfully made.</returns>
        async Task<ConnectionResult> Connect(string ssid, string password)
        {
            return await Connect(ssid, password, TimeSpan.FromSeconds(90), CancellationToken.None);
        }

        /// <summary>
        /// Disconnect from the the currently active access point.
        /// </summary>
        /// <remarks>
        /// Setting turnOffWiFiInterface to true will call StopWiFiInterface following
        /// the disconnection from the current access point.
        /// </remarks>
        /// <param name="turnOffWiFiInterface">Should the WiFi interface be turned off?</param>
        Task<ConnectionResult> Disconnect(bool turnOffWiFiInterface);

        /// <summary>
        /// Get the list of access points.
        /// </summary>
        /// <remarks>
        /// The network must be started before this method can be called.
        /// </remarks>
        /// <returns>An `IList` (possibly empty) of access points.</returns>
        public Task<IList<WifiNetwork>> Scan()
        {
            return Scan(TimeSpan.FromMilliseconds(-1));
        }

        Task<IList<WifiNetwork>> Scan(CancellationToken token);
        Task<IList<WifiNetwork>> Scan(TimeSpan timeout);

        /// <summary>
        /// Change the current WiFi antenna.
        /// </summary>
        /// <remarks>
        /// Allows the application to change the current antenna used by the WiFi adapter.  This
        /// can be made to persist between reboots / power cycles by setting the persist option
        /// to true.
        /// </remarks>
        /// <param name="antenna">New antenna to use.</param>
        /// <param name="persist">Make the antenna change persistent.</param>
        void SetAntenna(AntennaType antenna, bool persist = true);
    }
}
