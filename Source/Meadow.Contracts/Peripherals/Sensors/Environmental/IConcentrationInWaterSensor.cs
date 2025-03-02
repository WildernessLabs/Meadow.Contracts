using Meadow.Units;

namespace Meadow.Peripherals.Sensors.Environmental;

/// <summary>
/// Sensor that returns a concentration in water unit
/// </summary>
public interface IConcentrationInWaterSensor : ISamplingSensor<ConcentrationInWater>
{
    /// <summary>
    /// Last value read from the sensor
    /// </summary>
    ConcentrationInWater? Concentration { get; }
}
