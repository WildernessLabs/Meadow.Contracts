using Meadow.Units;
using System.Threading.Tasks;

namespace Meadow.Hardware;

/// <summary>
/// Interface for receiving current loop signals from industrial sensors
/// </summary>
public interface ICurrentLoopReceiver
{
    /// <summary>
    /// Gets the input current for the receiver
    /// </summary>
    /// <returns>A task representing the asynchronous operation</returns>
    Task<Current> GetInputCurrent();
}
