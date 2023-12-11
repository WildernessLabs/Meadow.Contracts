﻿namespace Meadow.Peripherals.Sensors.Location.Gnss;

// TODO: Should this be a struct with fields?
/// <summary>
/// Dimensional type of the fix.
/// </summary>
public enum DimensionalFixType
{
    /// <summary>
    /// No positional fix.
    /// </summary>
    None = 1,
    /// <summary>
    /// Two dimensional positional fix.
    /// </summary>
    TwoD = 2,
    /// <summary>
    /// Three dimensional positional fix.
    /// </summary>
    ThreeD = 3
}
