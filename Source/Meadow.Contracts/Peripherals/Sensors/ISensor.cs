using System.Threading.Tasks;

namespace Meadow.Peripherals.Sensors;

/// <summary>
/// Abstraction for a simple sensor
/// </summary>
public interface ISensor
{
}

/// <summary>
/// Abstraction for a simple sensor
/// </summary>
public interface ISensor<T> : ISensor
{
    /// <summary>
    /// Convenience method to get the current sensor reading
    /// </summary>
    Task<T> Read();
}