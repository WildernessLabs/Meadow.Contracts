using Meadow.Networking;
using Meadow.Peripherals.Sensors.Location.Gnss;
namespace Meadow.Hardware;

/// <summary>
/// Provides an abstraction for a cellular INetworkAdapter
/// </summary>
public interface ICellNetworkAdapter : INetworkAdapter
{
    /// <summary>
    /// Gets the adapter's IMEI
    /// </summary>
    string Imei { get; }
    /// <summary>
    /// Gets the adapter's CSQ
    /// </summary>
    int Csq { get; }
    /// <summary>
    /// Gets the adapter's AT common output
    /// </summary>
    string AtCmdsOutput { get; }

    /// <summary>
    /// Timeout duration in seconds for online network scans
    /// </summary>
    const int networkScanTimeoutInSeconds = 600;

    /// <summary>
    /// Timeout duration in seconds for fetching cell signal quality
    /// </summary>
    const int signalQualityFetchTimeoutInSeconds = 120;

    /// <summary>
    /// Timeout duration in seconds for GNSS-related AT commands and output retrieval
    /// </summary>
    const int gnssFixTimeoutInSeconds = 600;

    /// <summary>
    /// Timeout duration in seconds to wait for the command execution.
    /// </summary>
    const int atCommandTimeoutInSeconds = 10;
    /// <summary>
    /// Performs an offline scan for networks detected by the adapter
    /// </summary>
    /// <returns>An array of CellNetwork objects representing available networks.</returns>
    CellNetwork[] OfflineNetworkScan();

    /// <summary>
    /// Get current signal quality
    /// </summary>
    /// <param name="timeout"></param>
    /// <return>Cell signal quality</return>
    int GetSignalQuality(int timeout = signalQualityFetchTimeoutInSeconds);

    /// <summary>
    /// Initiates an online network scan to detect available networks,
    /// bypassing the need to enter "Scan Mode"
    /// </summary>
    /// <param name="timeout">The scan timeout duration in seconds.</param>
    /// <returns>An array of CellNetwork objects representing available networks.</returns>
    CellNetwork[] ScanForAvailableNetworks(int timeout = networkScanTimeoutInSeconds);

    /// Execute GNSS-related AT commands and retrieve combined output, including NMEA sentences
    /// <param name="resultTypes">An array of supported GNSS result types for data processing.</param>
    /// <param name="timeout">The GNSS scan timeout duration in seconds.</param>
    /// <returns>A string containing combined output from GNSS-related AT commands, including NMEA sentences.</returns>
    string FetchGnssAtCmdsOutput(IGnssResult[] resultTypes, int timeout = gnssFixTimeoutInSeconds);

    /// <summary>
    /// Send an attention (AT) command to the modem.
    /// </summary>
    /// <param name="cmd">A valid command to send.</param>
    /// <param name="timeout">The send timout duration in seconds.</param>
    void SendAtCmd(string cmd, int timeout = atCommandTimeoutInSeconds);
}