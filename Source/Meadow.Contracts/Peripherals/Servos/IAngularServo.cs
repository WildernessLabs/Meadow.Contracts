using Meadow.Units;

namespace Meadow.Peripherals.Servos;

/// <summary>
/// Represents an angular servo interface, extending the basic servo interface with additional properties and methods for controlling angular position.
/// </summary>
public interface IAngularServo : IServo
{
    /// <summary>
    /// Rotates the servo to the specified angle.
    /// </summary>
    /// <param name="angle">The target angle to rotate to.</param>
    /// <returns>A task that represents the asynchronous rotate operation.</returns>
    void RotateTo(Angle angle);

    /// <summary>
    /// Gets the current angle of the servo.
    /// </summary>
    Angle Angle { get; }

    /// <summary>
    /// Gets the minimum angle that the servo can rotate to.
    /// </summary>
    Angle MinimumAngle { get; }

    /// <summary>
    /// Gets the maximum angle that the servo can rotate to.
    /// </summary>
    Angle MaximumAngle { get; }
}
