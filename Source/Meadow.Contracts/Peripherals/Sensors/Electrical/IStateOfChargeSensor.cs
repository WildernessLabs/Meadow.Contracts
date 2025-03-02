using System.Threading.Tasks;

namespace Meadow.Peripherals.Sensors;

/// <summary>
/// State-of-charge sensor interface requirements.
/// </summary>
public interface IStateOfChargeSensor : ISensor<double>
{
    /// <summary>
    /// Reads the current state of charge of the sensor
    /// </summary>
    public ValueTask<double> ReadStateOfCharge();
}
