using Meadow.Units;
using System;
using System.Threading.Tasks;

namespace Meadow.Peripherals.Sensors;

/// <summary>
/// Electrical Current sensor interface requirements.
/// </summary>
public interface ICurrentSensor : ISensor<Current>
{
    /// <summary>
    /// Last value read from the Current sensor.
    /// </summary>
    [Obsolete("Use ReadCurrent", false)]
    Current? Current { get; }

    /// <summary>
    /// Reads the instantaneous current of the sensor
    /// </summary>
    ValueTask<Current> ReadCurrent();
}
