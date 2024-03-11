namespace Meadow.Hardware;

/// <summary>
/// Represents an interface for reading CAN frames.
/// </summary>
public interface ICanBus
{
    /// <summary>
    /// Reads a CAN frame.
    /// </summary>
    /// <returns>The read CAN frame, or null if no frame is available.</returns>
    public CanFrame? Read();
}
