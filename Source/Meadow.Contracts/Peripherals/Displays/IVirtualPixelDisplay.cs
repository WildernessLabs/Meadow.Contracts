namespace Meadow.Peripherals.Displays;

/// <summary>
/// Represents a virtual pixel display that provides a resizable renderer.
/// </summary>
public interface IVirtualPixelDisplay : IPixelDisplay
{
    /// <summary>
    /// Gets the resizable pixel display renderer.
    /// </summary>
    IPixelDisplay Renderer { get; }
}