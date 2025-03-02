namespace Meadow.Peripherals.Sensors.Color;

/// <summary>
/// Color sensor interface requirements.
/// </summary>
public interface IColorSensor : ISamplingSensor<Meadow.Color>
{
    /// <summary>
    /// Last color read from the sensor.
    /// </summary>
    Meadow.Color? Color { get; }
}