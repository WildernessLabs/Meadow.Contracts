using Meadow.Units;
using System.Threading;
using System.Threading.Tasks;

namespace Meadow.Peripherals.Motors;

/// <summary>
/// Represents an interface for controlling a positional motor.
/// </summary>
public interface IPositionalMotor : IVariableSpeedMotor
{
    /// <summary>
    /// Gets the current position of the motor.
    /// </summary>
    Angle Position { get; }

    /// <summary>
    /// Moves the motor to the specified position with the given velocity.
    /// </summary>
    /// <param name="position">The target position to move to.</param>
    /// <param name="velocity">The angular velocity of the motor during the movement.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    Task GoTo(Angle position, AngularVelocity velocity, CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Moves the motor to the specified position and direction with the given velocity.
    /// </summary>
    /// <param name="position">The target position to move to.</param>
    /// <param name="direction">The direction in which to move the motor.</param>
    /// <param name="velocity">The angular velocity of the motor during the movement.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    Task GoTo(Angle position, RotationDirection direction, AngularVelocity velocity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Resets the position of the motor.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    Task ResetPosition(CancellationToken cancellationToken = default(CancellationToken));

    /// <summary>
    /// Rotates the motor by the specified angle and direction with the given velocity.
    /// </summary>
    /// <param name="amountToRotate">The angle by which to rotate the motor.</param>
    /// <param name="direction">The direction in which to rotate the motor.</param>
    /// <param name="velocity">The angular velocity of the motor during the rotation.</param>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    Task Rotate(Angle amountToRotate, RotationDirection direction, AngularVelocity velocity, CancellationToken cancellationToken = default);
}