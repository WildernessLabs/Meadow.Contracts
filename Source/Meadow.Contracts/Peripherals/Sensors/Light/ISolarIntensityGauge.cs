﻿using Meadow.Units;

namespace Meadow.Peripherals.Sensors.Light;

/// <summary>
/// Contract for analog solar intensity gauge
/// </summary>
public interface ISolarIntensityGauge : ISensor<float>
{
    /// <summary>
    /// The maximum expected voltage when the solar panel is outputting 100% power
    /// </summary>
    Voltage MaxVoltageReference { get; }
    /// <summary>
    /// The minimum expected voltage when the solar panel is outputting 0% power
    /// </summary>
    Voltage MinVoltageReference { get; }

    /// <summary>
    /// The last available solar intensity reading, expressed as a percentage
    /// value between `0.0` and `1.0`, inclusively
    /// </summary>
    float? SolarIntensity { get; }
}