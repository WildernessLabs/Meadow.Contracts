using Meadow.Hardware;
/// <summary>
/// Represents channel information for voltage input channels on Temco Controls T3 modules.
/// Provides metadata about voltage input capabilities and configuration.
/// </summary>
public class VoltageInputChannelInfo : IChannelInfo
{
    /// <summary>
    /// Gets the name identifier for this voltage input channel.
    /// </summary>
    /// <value>The human-readable name of the voltage input channel.</value>
    public string Name { get; }

    /// <summary>
    /// Initializes a new instance of the VoltageInputChannelInfo class.
    /// </summary>
    /// <param name="name">The name identifier for the voltage input channel.</param>
    public VoltageInputChannelInfo(string name)
    {
        Name = name;
    }
}
