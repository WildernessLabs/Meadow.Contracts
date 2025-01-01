﻿using Meadow.Units;

namespace Meadow.Peripherals.Sensors;

/// <summary>
/// Volumetric flow sensor interface requirements.
/// </summary>
public interface IVolumetricFlowSensor : ISamplingSensor<VolumetricFlow>
{
    /// <summary>
    /// Last value read from the sensor.
    /// </summary>
    public VolumetricFlow Flow { get; }
}
