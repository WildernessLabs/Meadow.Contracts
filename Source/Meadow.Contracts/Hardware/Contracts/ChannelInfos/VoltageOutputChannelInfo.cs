using Meadow.Hardware;
using Meadow.Units;
/// <summary>
/// Represents channel information for voltage output channels on Temco Controls T3 modules.
/// Provides metadata about voltage output capabilities, configuration, and operational limits.
/// </summary>
public class VoltageOutputChannelInfo : IChannelInfo
{
    /// <summary>
    /// Gets the name identifier for this voltage output channel.
    /// </summary>
    /// <value>The human-readable name of the voltage output channel.</value>
    public string Name { get; }

    /// <summary>
    /// Gets the maximum voltage that can be output on this channel.
    /// </summary>
    /// <value>The maximum voltage limit for safe operation of this output channel.</value>
    public Voltage MaxVoltage { get; }

    /// <summary>
    /// Initializes a new instance of the VoltageOutputChannelInfo class.
    /// </summary>
    /// <param name="name">The name identifier for the voltage output channel.</param>
    /// <param name="maxVoltage">The maximum voltage that can be safely output on this channel.</param>
    public VoltageOutputChannelInfo(string name, Voltage maxVoltage)
    {
        Name = name;
        MaxVoltage = maxVoltage;
    }
}
