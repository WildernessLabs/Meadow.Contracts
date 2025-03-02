using Meadow.Units;

namespace Meadow.Peripherals.Sensors.Environmental;

/// <summary>
/// Potential Hydrogen (pH) sensor interface requirements.
/// </summary>
public interface IPotentialHydrogenSensor : ISamplingSensor<PotentialHydrogen>
{
    /// <summary>
    /// Last value read from the Potential Hydrogen sensor.
    /// </summary>
    public PotentialHydrogen? pH { get; }
}
