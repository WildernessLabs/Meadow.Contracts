using Meadow.Networking;

namespace Meadow.Hardware
{
    public interface ICellNetworkAdapter : INetworkAdapter
    {
        /// <summary>
        /// Returns a list of cellular networks
        /// </summary>
        CellNetwork[]? Scan();
    }
}
