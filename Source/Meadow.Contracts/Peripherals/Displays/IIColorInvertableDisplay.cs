namespace Meadow.Peripherals.Displays;

/// <summary>
/// Represents a display that supports inverting colors
/// </summary>
public interface IColorInvertableDisplay : IPixelDisplay
{
    /// <summary>
    /// Invert the display colors
    /// True to invert, false for normal colors
    /// </summary>
    public void InvertDisplayColor(bool invert);

    /// <summary>
    /// Gets whether the display color is inverted
    /// </summary>
    public bool IsColorInverted { get; }
}