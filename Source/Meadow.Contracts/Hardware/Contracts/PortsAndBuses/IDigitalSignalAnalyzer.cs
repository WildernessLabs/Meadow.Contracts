using Meadow.Units;

namespace Meadow.Hardware;

/// <summary>
/// Provides analysis capabilities for digital signals, measuring frequency and duty cycle characteristics.
/// </summary>
public interface IDigitalSignalAnalyzer
{
    /// <summary>
    /// Gets the current sensor count
    /// </summary>
    public ulong GetCount();

    /// <summary>
    /// Takes an instantaneous measurement of the signal frequency.
    /// </summary>
    /// <returns>The current frequency of the digital signal.</returns>
    public Frequency GetFrequency();

    /// <summary>
    /// Calculates the average frequency over the measurement period.
    /// </summary>
    /// <returns>The mean frequency of the digital signal.</returns>
    public Frequency GetMeanFrequency();

    /// <summary>
    /// Measures the duty cycle of the digital signal.
    /// </summary>
    /// <returns>
    /// The duty cycle as a ratio between 0 and 1, where 0 represents always low 
    /// and 1 represents always high.
    /// </returns>
    public double GetDutyCycle();
}
