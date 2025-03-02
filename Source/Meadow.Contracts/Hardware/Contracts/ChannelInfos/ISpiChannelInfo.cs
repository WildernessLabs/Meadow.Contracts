namespace Meadow.Hardware
{
    /// <summary>
    /// Represents the communication channel information for an SPI channel.
    /// </summary>
    public interface ISpiChannelInfo : IDigitalChannelInfo
    {
        /// <summary>
        /// Gets the line types supported by the SPI channel.
        /// </summary>
        SpiLineType LineTypes { get; }
        /// <summary>
        /// Gets the system bus number for the channel
        /// </summary>
        int BusNumber { get; }
    }
}