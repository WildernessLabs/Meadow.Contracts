﻿using Meadow.Units;
using System;

namespace Meadow.Peripherals.Sensors.Moisture
{
    public interface IMoistureSensor : ISamplingSensor<double>
    {
        /// <summary>
        /// Last value read from the moisture sensor.
        /// </summary>
        double? Moisture { get; }

        /// <summary>
        /// Raised when a new sensor reading has been made. To enable, call StartSampling().
        /// </summary>
        event EventHandler<IChangeResult<double>> HumidityUpdated;
    }
}