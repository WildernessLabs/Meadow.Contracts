namespace Meadow.Hardware;

/// <summary>
/// Represents SPI channel information.
/// </summary>
public class SpiChannelInfo : DigitalChannelInfoBase, ISpiChannelInfo
{
    /// <summary>
    /// Gets the supported line types of the SPI channel.
    /// </summary>
    public SpiLineType LineTypes { get; protected set; }

    /// <inheritdoc/>
    public int BusNumber { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpiChannelInfo"/> class with the specified parameters.
    /// </summary>
    /// <param name="name">The name of the SPI channel.</param>
    /// <param name="lineTypes">The supported line types of the SPI channel.</param>
    /// <param name="busNumber">The system bus number of SPI channel</param>
    /// <param name="pullDownCapable">Indicates whether the channel is capable of pull-down.</param>
    /// <param name="pullUpCapable">Indicates whether the channel is capable of pull-up.</param>
    public SpiChannelInfo(string name,
        SpiLineType lineTypes,
        int busNumber = 0,
        bool pullDownCapable = false,
        bool pullUpCapable = false)
        : base(
            name,
            inputCapable: true,
            outputCapable: true,
            interruptCapable: false, // ?? i mean, technically, yes, but will we have events?
            pullDownCapable: pullDownCapable,
            pullUpCapable: pullUpCapable,
            inverseLogic: false) //TODO: switch to C# 7.2+ to get rid of trailing names
    {
        LineTypes = lineTypes;
    }
}