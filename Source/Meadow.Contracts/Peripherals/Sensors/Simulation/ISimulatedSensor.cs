using System;

namespace Meadow.Peripherals.Sensors;

/// <summary>
/// Represents a simulated sensor for a specific unit type with customizable simulation behaviors
/// </summary>
public interface ISimulatedSensor<TUNIT> : ISimulatedSensor
    where TUNIT : struct
{
    /// <inheritdoc/>
    new Type ValueType => typeof(TUNIT);

    /// <summary>
    /// The minimum unit value simulation can produce
    /// </summary>
    TUNIT MinimumSimulatedValue { get; set; }
    /// <summary>
    /// The maximum unit value simulation can produce
    /// </summary>
    TUNIT MaximumSimulatedValue { get; set; }
}

/// <summary>
/// Represents a simulated sensor with customizable simulation behaviors.
/// </summary>
public interface ISimulatedSensor
{
    /// <summary>
    /// Gets an array of supported simulation behaviors for the sensor.
    /// </summary>
    SimulationBehavior[] SupportedBehaviors { get; }

    /// <summary>
    /// Gets the type of the sensor's value.
    /// </summary>
    Type ValueType { get; }

    /// <summary>
    /// Sets the simulated value for the sensor.
    /// </summary>
    /// <param name="value">The value to set for the sensor.</param>
    void SetSensorValue(object value);

    /// <summary>
    /// Starts the simulation with the specified behavior.
    /// </summary>
    /// <param name="behavior">The simulation behavior to start.</param>
    void StartSimulation(SimulationBehavior behavior);
}
