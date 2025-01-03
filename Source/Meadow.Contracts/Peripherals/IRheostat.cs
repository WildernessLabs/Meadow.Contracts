using Meadow.Units;

namespace Meadow.Hardware;

/// <summary>
/// Extensions for the IRheostat
/// </summary>
public static class RheostatExtensions
{
    /// <summary>
    /// Gets the current position as a percentage of maximum resistance (0-100).
    /// </summary>
    /// <example>
    /// var rheostat = new Rheostat(maxResistance: new Resistance(100));
    /// rheostat.Resistance = new Resistance(75);
    /// double position = rheostat.CurrentPosition; // Returns 75.0
    /// </example>
    public static int GetCurrentPosition(this IRheostat self)
    {
        return (int)((self.Resistance.Ohms / self.MaxResistance.Ohms) * 100f);
    }
}

/// <summary>
/// Represents an adjustable resistor (rheostat).
/// </summary>
public interface IRheostat
{
    /// <summary>
    /// Gets the maximum resistance of the rheostat.
    /// </summary>
    Resistance MaxResistance { get; }

    /// <summary>
    /// Gets or sets the current resistance of the rheostat.
    /// </summary>
    Resistance Resistance { get; set; }
}
