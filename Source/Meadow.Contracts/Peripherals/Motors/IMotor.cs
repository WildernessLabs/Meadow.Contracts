using System;
using System.Threading;
using System.Threading.Tasks;

namespace Meadow.Peripherals.Motors;

/// <summary>
/// Represents an interface for controlling a motor.
/// </summary>
public interface IMotor
{
    /// <summary>
    /// Raised when the movement state of the motor changes
    /// </summary>
    event EventHandler<bool>? StateChanged;

    /// <summary>
    /// Gets the current rotation direction of the motor.
    /// </summary>
    RotationDirection Direction { get; }

    /// <summary>
    /// Runs the motor for a specified duration with the given parameters.
    /// </summary>
    /// <param name="runTime">The duration for which the motor should run.</param>
    /// <param name="direction">The rotation direction of the motor.</param>
    /// <param name="cancellationToken">Optional cancellation token to stop the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task RunFor(TimeSpan runTime, RotationDirection direction, CancellationToken cancellationToken = default);

    /// <summary>
    /// Runs the motor continuously with the given parameters.
    /// </summary>
    /// <param name="direction">The rotation direction of the motor.</param>
    /// <param name="cancellationToken">Optional cancellation token to stop the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task Run(RotationDirection direction, CancellationToken cancellationToken = default);

    /// <summary>
    /// Stops the motor.
    /// </summary>
    /// <param name="cancellationToken">Optional cancellation token to stop the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task Stop(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a value indicating whether the motor is currently in motion.
    /// </summary>
    /// <remarks>
    /// This property will return true if the motor is currently executing a run command. this may or may not account for motor ramp up or down, depending on the motor/drive capabilities.
    /// This property may also return true if external forces are causing the motor to rotate, provided the motor/drive is capable of determining the condition.
    /// </remarks>
    bool IsMoving { get; }
}
