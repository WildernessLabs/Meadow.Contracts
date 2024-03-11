namespace Meadow.Hardware;

/// <summary>
/// Represents a J1939 frame, extending the CanFrame class.
/// </summary>
public class J1939Frame : ExtendedCanFrame
{
    /// <summary>
    /// Creates a J1939Frame from a given CanFrame.
    /// </summary>
    /// <param name="frame">The CanFrame to convert to a J1939Frame.</param>
    /// <returns>A new instance of J1939Frame.</returns>
    public static J1939Frame FromCanFrame(ExtendedCanFrame frame)
    {
        return new J1939Frame(frame);
    }

    /// <summary>
    /// Initializes a new instance of the J1939Frame class with the specified CanFrame.
    /// </summary>
    /// <param name="frame">The CanFrame to use for initialization.</param>
    private J1939Frame(ExtendedCanFrame frame)
        : base(frame)
    {
    }

    /// <summary>
    /// Gets the priority of the J1939 frame.
    /// </summary>
    public byte Priority => (byte)((ID >> 26) & 0b111);

    /// <summary>
    /// Gets the priority group number of the J1939 frame.
    /// </summary>
    public int PriorityGroupNumber => ID >> 8 & 0x3ffff;

    /// <summary>
    /// Gets the source address of the J1939 frame.
    /// </summary>
    public byte SourceAddress => (byte)(ID & 0xff);

    /// <summary>
    /// Gets a value indicating whether the J1939 frame is reserved.
    /// </summary>
    public bool Reserved => (ID & (1 << 25)) != 0;

    /// <summary>
    /// Gets a value indicating whether the J1939 frame is on a data page.
    /// </summary>
    public bool DataPage => (ID & (1 << 24)) != 0;

    /// <summary>
    /// Gets the PDU format of the J1939 frame.
    /// </summary>
    public byte PDUFormat => (byte)((ID >> 16) & 0xff);

    /// <summary>
    /// Gets the PDU specific of the J1939 frame.
    /// </summary>
    public byte PDUSpecific => (byte)((ID >> 8) & 0xff);
}
