using Meadow.Hardware;
/// <summary>
/// Represents channel information for current input channels on Temco Controls T3 modules.
/// Provides metadata about current input capabilities and configuration.
/// </summary>
public class CurrentInputChannelInfo : IChannelInfo
{
    /// <summary>
    /// Gets the name identifier for this current input channel.
    /// </summary>
    /// <value>The human-readable name of the current input channel.</value>
    public string Name { get; }

    /// <summary>
    /// Initializes a new instance of the CurrentInputChannelInfo class.
    /// </summary>
    /// <param name="name">The name identifier for the current input channel.</param>
    public CurrentInputChannelInfo(string name)
    {
        Name = name;
    }
}
