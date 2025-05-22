using Meadow.Units;

namespace Meadow.Hardware;

/// <summary>
/// Defines the contract for voltage output controllers on Temco Controls T3 modules.
/// Provides factory methods for creating voltage output port instances with optional initial values.
/// </summary>
public interface IVoltageOutputController
{
    /// <summary>
    /// Creates a new voltage output port instance associated with the specified pin.
    /// </summary>
    /// <param name="pin">The physical pin to associate with the voltage output port.</param>
    /// <returns>A new IVoltageOutputPort instance configured for the specified pin.</returns>
    IVoltageOutputPort CreateVoltageOutputPort(IPin pin);

    /// <summary>
    /// Creates a new voltage output port instance associated with the specified pin and sets an initial voltage value.
    /// </summary>
    /// <param name="pin">The physical pin to associate with the voltage output port.</param>
    /// <param name="initialVoltage">The initial voltage value to set on the output port upon creation.</param>
    /// <returns>A new IVoltageOutputPort instance configured for the specified pin with the initial voltage applied.</returns>
    IVoltageOutputPort CreateVoltageOutputPort(IPin pin, Voltage initialVoltage);
}
