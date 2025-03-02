namespace Meadow.Hardware;

/// <summary>
/// Represents an item that can be colored
/// </summary>
public interface IColorable
{
    /// <summary>
    /// Sets the color of the target
    /// </summary>
    /// <param name="color">The color to set</param>
    void SetColor(Color color);

    /// <summary>
    /// Gets the color of the target
    /// </summary>
    Color GetColor();
}
