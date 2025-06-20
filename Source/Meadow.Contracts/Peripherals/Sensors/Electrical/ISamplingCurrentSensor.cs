using Meadow.Units;

namespace Meadow.Peripherals.Sensors;

/// <summary>
/// Electrical Current sensor interface requirements.
/// </summary>
public interface ISamplingCurrentSensor : ISamplingSensor<Current>, ICurrentSensor
{
}
