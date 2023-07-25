using Meadow.Gateway.WiFi;
using System;
using System.Net;
using System.Net.NetworkInformation;

namespace Meadow.Hardware
{
    /// <summary>
    /// Data relating to a Cell connection.
    /// </summary>
    public class CellNetworkConnectionEventArgs : NetworkConnectionEventArgs
    {
        
        /// <summary>
        /// Construct a CellNetworkConnectionEventArgs request.
        /// </summary>
        /// <param name="ipAddress">IP address of the device.</param>
        /// <param name="subnet">Subnet of the device.</param>
        /// <param name="gateway">Gateway address of the device.</param>
        public CellNetworkConnectionEventArgs(IPAddress ipAddress, IPAddress subnet, IPAddress gateway)
            : base(ipAddress, subnet, gateway)
        {
        }
    }
}
