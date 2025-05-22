using Meadow.Units;
using System.Threading.Tasks;

namespace Meadow.Hardware;

/// <summary>
/// Defines the contract for voltage input ports on Temco Controls T3 modules.
/// Provides methods for reading voltage measurements from analog input channels.
/// </summary>
public interface IVoltageInputPort
{
    /// <summary>
    /// Gets the physical pin associated with this voltage input port.
    /// </summary>
    /// <value>The IPin representing the hardware connection for voltage input.</value>
    IPin Pin { get; }

    /// <summary>
    /// Asynchronously reads the voltage value from the input port.
    /// </summary>
    /// <returns>A ValueTask containing the measured voltage value.</returns>
    ValueTask<Voltage> Read();
}
