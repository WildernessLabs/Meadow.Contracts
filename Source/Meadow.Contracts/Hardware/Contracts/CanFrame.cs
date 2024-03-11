using System;

namespace Meadow.Hardware;

public class ExtendedCanFrame : CanFrame

{
    /// <summary>
    /// Gets or sets the ID of the CAN frame.
    /// </summary>
    public int ID { get; set; }

    public ExtendedCanFrame(int id, byte[] data)
        : this(id, data, 0, data.Length)
    {
        ID = id;
    }

    public ExtendedCanFrame(int id, byte[] data, int offset, int length)
        : base(data, offset, length)
    {
        ID = id;
    }

    /// <summary>
    /// Initializes a new instance of the ExtendedCanFrame class with the specified CanFrame.
    /// </summary>
    /// <param name="other">The ExtendedCanFrame to use for initialization.</param>
    protected ExtendedCanFrame(ExtendedCanFrame other)
        : this(other.ID, other.Data)
    {
        Data = other.Data;
    }
}

public class StandardCanFrame : CanFrame
{
    /// <summary>
    /// Gets or sets the ID of the CAN frame.
    /// </summary>
    public short ID { get; set; }

    public StandardCanFrame(short id, byte[] data)
        : this(id, data, 0, data.Length)
    {
        ID = id;
    }

    public StandardCanFrame(short id, byte[] data, int offset, int length)
        : base(data, offset, length)
    {
        ID = id;
    }
}

/// <summary>
/// Represents a generic CAN frame.
/// </summary>
public abstract class CanFrame
{
    /// <summary>
    /// Initializes a new instance of the CanFrame class.
    /// </summary>
    public CanFrame(byte[] data)
        : this(data, 0, data.Length)
    {
    }

    /// <summary>
    /// Initializes a new instance of the CanFrame class.
    /// </summary>
    public CanFrame(byte[] data, int offset, int length)
    {
        if (length > 8)
        {
            throw new ArgumentException($"Frame data cannot exceed 8 bytes");
        }

        Data = new byte[length];
        Array.Copy(data, offset, Data, 0, length);
    }

    /// <summary>
    /// Initializes a new instance of the CanFrame class with the specified CanFrame.
    /// </summary>
    /// <param name="other">The CanFrame to use for initialization.</param>
    protected CanFrame(CanFrame other)
    {
        Data = other.Data;
    }

    /// <summary>
    /// Gets or sets the data of the CAN frame.
    /// </summary>
    public byte[] Data { get; set; }
}
