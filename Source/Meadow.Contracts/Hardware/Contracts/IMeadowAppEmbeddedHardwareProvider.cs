namespace Meadow;

/// <summary>
/// An interface for a factory class responsible for generating IMeadowAppEmbeddedHardware instances at run time
/// </summary>
public interface IMeadowAppEmbeddedHardwareProvider<H>
    where H : IMeadowAppEmbeddedHardware
{
    /// <summary>
    /// Creates an IMeadowAppEmbeddedHardware based on detected runtime conditions
    /// </summary>
    H Create(IMeadowDevice device);
}
