using System.Threading.Tasks;

namespace Meadow.Hardware;

/// <summary>
/// Defines the contract for voltage input controllers on Temco Controls T3 modules.
/// Provides factory methods for creating voltage input port instances.
/// </summary>
public interface IVoltageInputController
{
    /// <summary>
    /// Creates a new voltage input port instance associated with the specified pin.
    /// </summary>
    /// <param name="pin">The physical pin to associate with the voltage input port.</param>
    /// <returns>A new IVoltageInputPort instance configured for the specified pin.</returns>
    Task<IVoltageInputPort> CreateVoltageInputPort(IPin pin);
}
