﻿namespace Meadow.Hardware;

/// <summary>
/// Standard I2C Bus speeds
/// </summary>
public enum I2cBusSpeed
{
    /// <summary>
    /// Standard 100 kHz clock frequency
    /// </summary>
    Standard = 100000,
    /// <summary>
    /// Fast 400 kHz clock frequency
    /// </summary>
    Fast = 400000,
    /// <summary>
    /// Fast-Plus 1 MHz clock frequency
    /// </summary>
    FastPlus = 1000000,
    /// <summary>
    /// High 3.4 MHz clock frequency
    /// </summary>
    High = 3400000,
    /// <summary>
    /// Ultra-Fast 5 MHz clock frequency
    /// </summary>
    UltraFast = 5000000

}
