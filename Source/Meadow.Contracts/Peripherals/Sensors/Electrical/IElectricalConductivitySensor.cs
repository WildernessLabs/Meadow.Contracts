using Meadow.Units;

namespace Meadow.Peripherals.Sensors;

/// <summary>
/// Electrical Conductivity sensor interface requirements.
/// </summary>
public interface IElectricalConductivitySensor : ISamplingSensor<Conductivity>
{
    /// <summary>
    /// Last value read from the Conductivity sensor.
    /// </summary>
    public Conductivity? Conductivity { get; }
}
