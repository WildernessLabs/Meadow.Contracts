using Meadow.Units;

namespace Meadow.Peripherals.Sensors.Environmental;

/// <summary>
/// Turbidity sensor interface requirements.
/// </summary>
public interface ITurbiditySensor : ISamplingSensor<Turbidity>
{
    /// <summary>
    /// Last value read from the Turbidity sensor.
    /// </summary>
    public Turbidity? Turbidity { get; }
}
