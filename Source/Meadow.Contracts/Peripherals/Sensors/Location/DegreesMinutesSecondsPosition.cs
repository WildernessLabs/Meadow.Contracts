using System;

namespace Meadow.Peripherals.Sensors.Location;

// TODO: Should this be a struct with fields?
/// <summary>
/// Represents a positional point on a spherical axis.
/// </summary>
public class DegreesMinutesSecondsPosition
{
    /// <summary>
    /// Latitudinal: -90° to 90°
    /// Longitudinal: -180° to 180°
    /// </summary>
    public int Degrees { get; set; }
    /// <summary>
    /// 0' to 60'
    /// </summary>
    public decimal Minutes { get; set; }
    /// <summary>
    /// 0" to 60"
    /// </summary>
    public decimal Seconds { get; set; }
    /// <summary>
    /// Cardinal direction.
    /// </summary>
    public CardinalDirection Direction;

    /// <summary>
    /// Returns a string that represents the position in the format dd° mm' ss"X, where X represents the cardinal direction of the position.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        var direction = Direction switch
        {
            CardinalDirection.North => "N",
            CardinalDirection.South => "S",
            CardinalDirection.East => "E",
            CardinalDirection.West => "W",
            CardinalDirection.Unknown => "Unknown",
            _ => throw new ArgumentOutOfRangeException(nameof(Direction), Direction, null)
        };
        return $"{Degrees:f2}° {Minutes:f2}' {Seconds:f2}\"{direction}";
    }

    /// <summary>
    /// Converts the geographical position from degrees, minutes, and seconds (DMS) to a decimal format for latitude or longitude.
    /// </summary>
    /// <returns>A double value representing the converted decimal position.</returns>
    public double ToDecimal()
    {
        double result = Degrees + (double)Minutes / 60 + (double)Seconds / 3600;

        if (Direction == CardinalDirection.South || Direction == CardinalDirection.West)
        {
            result = -result;
        }

        return result;
    }
}
