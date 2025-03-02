namespace Meadow.Hardware
{
    /// <summary>
    /// Represents the type of I2C channel function.
    /// </summary>
    public enum I2cChannelFunctionType
    {
        /// <summary>
        /// Data channel function.
        /// </summary>
        Data,
        /// <summary>
        /// Clock channel function.
        /// </summary>
        Clock
    }

    /// <summary>
    /// Represents the I2C channel information.
    /// </summary>
    public interface II2cChannelInfo : IDigitalChannelInfo, ICommunicationChannelInfo
    {
        /// <summary>
        /// Gets the I2C channel function type.
        /// </summary>
        I2cChannelFunctionType ChannelFunction { get; }
        /// <summary>
        /// Gets the system bus number for the channel
        /// </summary>
        int BusNumber { get; }
    }
}