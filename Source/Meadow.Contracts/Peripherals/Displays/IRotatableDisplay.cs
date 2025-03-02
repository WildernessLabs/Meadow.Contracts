namespace Meadow.Peripherals.Displays;

/// <summary>
/// Represents a display that supports rotation in 90 degree increments
/// </summary>
public interface IRotatableDisplay : IPixelDisplay
{
    /// <summary>
    /// Set the rotation of the display
    /// </summary>
    /// <param name="rotation">The rotation</param>
    public void SetRotation(RotationType rotation);

    /// <summary>
    /// Gets the current display rotation
    /// </summary>
    public RotationType Rotation { get; }
}