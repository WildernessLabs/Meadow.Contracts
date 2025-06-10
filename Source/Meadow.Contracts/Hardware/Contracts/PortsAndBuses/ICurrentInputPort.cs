using Meadow.Units;
using System.Threading.Tasks;

namespace Meadow.Hardware;

/// <summary>
/// Defines the contract for current input ports on Temco Controls T3 modules.
/// Provides methods for reading current measurements from analog input channels.
/// </summary>
public interface ICurrentInputPort
{
    /// <summary>
    /// Gets the physical pin associated with this current input port.
    /// </summary>
    /// <value>The IPin representing the hardware connection for current input.</value>
    IPin Pin { get; }

    /// <summary>
    /// Asynchronously reads the current value from the input port.
    /// </summary>
    /// <returns>A ValueTask containing the measured current value.</returns>
    ValueTask<Current> Read();
}
