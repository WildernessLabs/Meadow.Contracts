using Meadow.Units;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Meadow.Peripherals.Motors;

/// <summary>
/// Represents an interface for controlling a motor with variable speed.
/// </summary>
public interface IVariableSpeedMotor : IMotor
{
    /// <summary>
    /// Gets the maximum run velocity for the motor
    /// </summary>
    AngularVelocity MaxVelocity { get; }

    /// <summary>
    /// Runs the motor for a specified duration with the given parameters.
    /// </summary>
    /// <param name="runTime">The duration for which the motor should run.</param>
    /// <param name="direction">The rotation direction of the motor.</param>
    /// <param name="angularVelocity">The AngularVelocity at which the motor should run (0 to 100).</param>
    /// <param name="cancellationToken">Optional cancellation token to stop the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task RunFor(TimeSpan runTime, RotationDirection direction, AngularVelocity angularVelocity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Runs the motor continuously with the given parameters.
    /// </summary>
    /// <param name="direction">The rotation direction of the motor.</param>
    /// <param name="angularVelocity">The AngularVelocity at which the motor should run (0 to 100).</param>
    /// <param name="cancellationToken">Optional cancellation token to stop the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task Run(RotationDirection direction, AngularVelocity angularVelocity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Runs the motor for a specified duration with the given parameters.
    /// </summary>
    /// <param name="runTime">The duration for which the motor should run.</param>
    /// <param name="direction">The rotation direction of the motor.</param>
    /// <param name="speed">The speed (as a percentage) at which the motor should run (0 to 100).</param>
    /// <param name="cancellationToken">Optional cancellation token to stop the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task RunFor(TimeSpan runTime, RotationDirection direction, float speed = 100, CancellationToken cancellationToken = default)
    {
        var velocity = MaxVelocity * (speed / 100);
        await RunFor(runTime, direction, velocity, cancellationToken);
    }

    /// <summary>
    /// Runs the motor continuously with the given parameters.
    /// </summary>
    /// <param name="direction">The rotation direction of the motor.</param>
    /// <param name="speed">The speed (as a percentage) at which the motor should run (0 to 100).</param>
    /// <param name="cancellationToken">Optional cancellation token to stop the operation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Run(RotationDirection direction, float speed = 100, CancellationToken cancellationToken = default)
    {
        var velocity = MaxVelocity * (speed / 100);
        await Run(direction, velocity, cancellationToken);
    }
}