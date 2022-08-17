﻿using System.Net;
using System.Net.NetworkInformation;

namespace Meadow.Hardware
{
    /// <summary>
    /// Delegate containing information about a network connection event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    public delegate void NetworkConnectionHandler(INetworkAdapter sender, NetworkConnectionEventArgs args);
    /// <summary>
    /// Delegate containing information about a network disconnection event
    /// </summary>
    /// <param name="sender"></param>
    public delegate void NetworkDisconnectionHandler(INetworkAdapter sender);

    /// <summary>
    /// Base interface for a network adapter
    /// </summary>
    public interface INetworkAdapter
    {
        /// <summary>
        /// Event raised when a network is connected
        /// </summary>
        event NetworkConnectionHandler NetworkConnected;
        /// <summary>
        /// Event raised when a network is disconnected
        /// </summary>
        event NetworkDisconnectionHandler NetworkDisconnected;

        /// <summary>
        /// Indicate if the network adapter is connected to an access point.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// IP Address of the network adapter.
        /// </summary>
        IPAddress IpAddress { get; }

        /// <summary>
        /// Subnet mask of the adapter.
        /// </summary>
        IPAddress SubnetMask { get; }

        /// <summary>
        /// Default gateway for the adapter.
        /// </summary>
        IPAddress Gateway { get; }

        /// <summary>
        /// Physical (MAC) address of the adapter
        /// </summary>
        PhysicalAddress MacAddress { get; }
    }
}