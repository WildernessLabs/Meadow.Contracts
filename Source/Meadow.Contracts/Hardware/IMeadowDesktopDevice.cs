namespace Meadow;

/// <summary>
/// Contract for desktop-specific Meadow devices
/// </summary>
public interface IMeadowDesktopDevice : IMeadowDevice
{
    /// <summary>
    /// Gets the desktop display width
    /// </summary>
    public int DisplayWidth { get; }
    /// <summary>
    /// Gets the desktop display height
    /// </summary>
    public int DisplayHeight { get; }
}
