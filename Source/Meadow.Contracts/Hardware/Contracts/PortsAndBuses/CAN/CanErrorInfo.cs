namespace Meadow.Hardware;

/// <summary>
/// Represents CAN bus error information
/// </summary>
public class CanErrorInfo
{
    /// <summary>
    /// The number of transmit errors detected 
    /// </summary>
    public byte TransmitErrorCount { get; set; }
    /// <summary>
    /// The number of receive errors detected 
    /// </summary>
    public byte ReceiveErrorCount { get; set; }
}
