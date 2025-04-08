using Meadow.Units;
using System;
using System.Threading.Tasks;

namespace Meadow.Peripherals.Sensors;

/// <summary>
/// Voltage sensor interface requirements.
/// </summary>
public interface IVoltageSensor : ISensor<Voltage>
{
    /// <summary>
    /// Last value read from the Voltage sensor.
    /// </summary>
    [Obsolete("Use ReadVoltage", false)]
    public Voltage? Voltage { get; }

    /// <summary>
    /// Reads the current voltage of the sensor
    /// </summary>
    public ValueTask<Voltage> ReadVoltage();
}
