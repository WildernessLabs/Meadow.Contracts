using Meadow.Units;

namespace Meadow.Peripherals.Sensors;

/// <summary>
/// Sampling temperature sensor interface requirements.
/// </summary>
public interface ISamplingTemperatureSensor : ITemperatureSensor, ISamplingSensor<Temperature>
{
    /// <summary>
    /// Last value read from the Temperature sensor.
    /// </summary>
    Temperature? Temperature { get; }
}