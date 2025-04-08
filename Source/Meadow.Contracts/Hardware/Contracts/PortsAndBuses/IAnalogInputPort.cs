using Meadow.Units;
using System.Threading.Tasks;

namespace Meadow.Hardware;

/// <summary>
/// Contract for ports that implement an analog input channel.
/// </summary>
public interface IAnalogInputPort : IAnalogPort
{
    /// <summary>
    /// The maximum voltage that the Analog Port can read. Typically 3.3V.
    /// This value is used to convert raw ADC values into voltage.
    /// </summary>
    Voltage ReferenceVoltage { get; }

    /// <summary>
    /// Gets the current voltage. For frequent reads, use StartUpdating() and StopUpdating()
    /// in conjunction with the SampleBuffer.
    /// </summary>
    /// <returns>The current voltage.</returns>
    Task<Voltage> Read();
}
