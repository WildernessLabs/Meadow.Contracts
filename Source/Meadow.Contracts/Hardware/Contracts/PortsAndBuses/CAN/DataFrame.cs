namespace Meadow.Hardware;

/// <summary>
/// Represents an abstract data frame for CAN communication, inheriting from Frame.
/// </summary>
public abstract class DataFrame : Frame
{
    /// <summary>
    /// Gets or sets the identifier for the data frame.
    /// </summary>
    public int ID { get; set; }

    /// <summary>
    /// Gets or sets the payload of the data frame.
    /// </summary>
    public byte[] Payload { get; set; } = new byte[0];
}
