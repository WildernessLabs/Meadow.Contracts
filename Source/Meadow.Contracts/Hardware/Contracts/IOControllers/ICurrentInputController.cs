using System.Threading.Tasks;

namespace Meadow.Hardware;

/// <summary>
/// Defines the contract for current input controllers on Temco Controls T3 modules.
/// Provides factory methods for creating current input port instances.
/// </summary>
public interface ICurrentInputController
{
    /// <summary>
    /// Creates a new current input port instance associated with the specified pin.
    /// </summary>
    /// <param name="pin">The physical pin to associate with the current input port.</param>
    /// <returns>A new ICurrentInputPort instance configured for the specified pin.</returns>
    Task<ICurrentInputPort> CreateCurrentInputPort(IPin pin);
}
