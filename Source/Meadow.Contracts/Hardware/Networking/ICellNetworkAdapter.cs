using Meadow.Networking;
using System.Collections.Generic;

namespace Meadow.Hardware
{

    public interface ICellNetworkAdapter : INetworkAdapter
    {
        /// <summary>
        /// Returns a list of cellular networks
        /// </summary>
        List <CellNetwork> Scan();
    }
}
