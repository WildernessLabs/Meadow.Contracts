namespace Meadow.Hardware;

/// <summary>
/// Represents information about an I2C channel
/// </summary>
public class I2cChannelInfo : DigitalChannelInfoBase, II2cChannelInfo
{
    /// <summary>
    /// Gets the function type of the I2C channel
    /// </summary>
    public I2cChannelFunctionType ChannelFunction { get; protected set; }

    /// <inheritdoc/>
    public int BusNumber { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="I2cChannelInfo"/> class
    /// </summary>
    /// <param name="name">The name of the I2C channel</param>
    /// <param name="channelFunction">The function type of the I2C channel</param>
    /// <param name="busNumber">The system bus number of I2C channel</param>
    /// <param name="pullDownCapable">Indicates whether the I2C channel is capable of pull-down</param>
    /// <param name="pullUpCapable">Indicates whether the I2C channel is capable of pull-up</param>
    public I2cChannelInfo(string name,
        I2cChannelFunctionType channelFunction,
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
        BusNumber = busNumber;
        ChannelFunction = channelFunction;
    }
}