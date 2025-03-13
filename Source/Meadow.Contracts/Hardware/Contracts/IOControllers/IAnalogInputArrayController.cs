namespace Meadow.Hardware;

/// <summary>
/// Controller for creating arrays of analog inputs from multiple pins.
/// </summary>
/// <remarks>
/// This interface provides functionality for simultaneously managing multiple analog input pins
/// as a unified array.
/// </remarks>
public interface IAnalogInputArrayController : IPinController
{
    /// <summary>
    /// Creates an array of analog inputs from the specified pins.
    /// </summary>
    /// <param name="pins">The collection of pins to use for the analog input array.</param>
    /// <returns>An instance of <see cref="IAnalogInputArray"/> configured with the specified pins.</returns>
    IAnalogInputArray CreateAnalogInputArray(params IPin[] pins);
}
