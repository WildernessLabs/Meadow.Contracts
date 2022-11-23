﻿using Meadow.Units;
using System;

namespace Meadow.Peripherals.Sensors.Motion
{
    /// <summary>
    /// Represents a generic magnetometer sensor that measures the strength and direction of a magnetic field
    /// </summary>
    public interface IMagnetometer : ISamplingSensor<MagneticField3D>
    {
        /// <summary>
        /// Last value read from the sensor
        /// </summary>
        MagneticField3D? MagneticField3d { get; }

        /// <summary>
        /// Raised when a new reading has been made. Events will only be raised
        /// while the driver is updating. To start, call the `StartUpdating()`
        /// method.
        /// </summary>
        event EventHandler<IChangeResult<MagneticField3D>> MagneticField3dUpdated;
    }
}