namespace Meadow;

/// <summary>
/// An interface for embedded hardware running the Meadow software stack
/// </summary>
public interface IMeadowAppEmbeddedHardware
{
    /// <summary>
    /// The base IMeadowDevice compute module that the hardware uses (e.g. F7, Raspberry Pi, etc)
    /// </summary>
    IMeadowDevice ComputeModule { get; }
}
