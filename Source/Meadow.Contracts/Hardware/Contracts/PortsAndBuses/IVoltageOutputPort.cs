using Meadow.Units;
using System.Threading.Tasks;

namespace Meadow.Hardware;

/// <summary>
/// Defines the contract for voltage output ports on Temco Controls T3 modules.
/// Provides methods for setting voltage output values on analog output channels.
/// </summary>
public interface IVoltageOutputPort
{
    /// <summary>
    /// Gets the physical pin associated with this voltage output port.
    /// </summary>
    /// <value>The IPin representing the hardware connection for voltage output.</value>
    IPin Pin { get; }

    /// <summary>
    /// Asynchronously sets the output voltage value for this port.
    /// </summary>
    /// <param name="value">The voltage value to output on this port.</param>
    /// <returns>A Task representing the asynchronous set operation.</returns>
    Task SetOutput(Voltage value);
}
