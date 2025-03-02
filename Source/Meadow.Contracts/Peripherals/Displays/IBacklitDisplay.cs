namespace Meadow.Peripherals.Displays;

/// <summary>
/// Defines a Display with a controllable backlight
/// </summary>
public interface IBacklitDisplay : IDisplay
{
    /// <summary>
    /// Sets the backlight intensity.
    /// </summary>
    /// <param name="intensity">Intensity value</param>
    /// <remarks>For displays with boolean power, use 0 for off and non-zero for on</remarks>
    void SetBacklightIntensity(byte intensity);
}
