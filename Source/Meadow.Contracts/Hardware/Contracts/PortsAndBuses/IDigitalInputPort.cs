namespace Meadow.Hardware;

/// <summary>
/// Contract for ports that are capable of reading digital inputs.
/// </summary>
public interface IDigitalInputPort : IDigitalPort
{
    /// <summary>
    /// Gets the current state of the port
    /// </summary>
    bool State { get; }
    /// <summary>
    /// Gets or sets the ResistorMode of the port
    /// </summary>
    ResistorMode Resistor { get; set; }
}