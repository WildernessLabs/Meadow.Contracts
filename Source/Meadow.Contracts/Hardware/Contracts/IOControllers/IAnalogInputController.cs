using Meadow.Units;

namespace Meadow.Hardware;

/// <summary>
/// Controller for analog input pins that enables creating individual analog input ports.
/// </summary>
/// <remarks>
/// This interface provides functionality for creating analog input ports from specific pins
/// to read analog voltage levels from external sources.
/// </remarks>
public interface IAnalogInputController : IPinController
{
    /// <summary>
    /// Creates an analog input port using the specified pin.
    /// </summary>
    /// <param name="pin">The pin to use for analog input.</param>
    /// <param name="voltageReference">Optional reference voltage for the analog input. If null, the default reference voltage will be used.</param>
    /// <returns>An instance of <see cref="IAnalogInputPort"/> configured for the specified pin.</returns>
    IAnalogInputPort CreateAnalogInputPort(IPin pin, Voltage? voltageReference = null);
}
