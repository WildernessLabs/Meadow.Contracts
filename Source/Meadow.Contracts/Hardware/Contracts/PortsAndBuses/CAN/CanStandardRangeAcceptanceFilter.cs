namespace Meadow.Hardware;

/// <summary>
/// Represents a CAN extended range acceptance filter.
/// </summary>
public class CanExtendedRangeAcceptanceFilter : CanAcceptanceFilter
{
    /// <summary>
    /// Gets the first (inclusive) accepted identifier in the range.
    /// </summary>
    public int FirstAcceptID { get; }

    /// <summary>
    /// Gets the last (inclusive) accepted identifier in the range.
    /// </summary>
    public int LastAcceptID { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CanExtendedRangeAcceptanceFilter"/> class with the specified range of accepted identifiers.
    /// </summary>
    /// <param name="firstAcceptID">The first accepted identifier in the range.</param>
    /// <param name="lastAcceptID">The last accepted identifier in the range.</param>
    public CanExtendedRangeAcceptanceFilter(int firstAcceptID, int lastAcceptID)
    {
        FirstAcceptID = firstAcceptID;
        LastAcceptID = lastAcceptID;
    }
}

/// <summary>
/// Represents a CAN standard range acceptance filter.
/// </summary>
public class CanStandardRangeAcceptanceFilter : CanAcceptanceFilter
{
    /// <summary>
    /// Gets the first (inclusive) accepted identifier in the range.
    /// </summary>
    public short FirstAcceptID { get; }

    /// <summary>
    /// Gets the last (inclusive) accepted identifier in the range.
    /// </summary>
    public short LastAcceptID { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CanStandardRangeAcceptanceFilter"/> class with the specified range of accepted identifiers.
    /// </summary>
    /// <param name="firstAcceptID">The first accepted identifier in the range.</param>
    /// <param name="lastAcceptID">The last accepted identifier in the range.</param>
    public CanStandardRangeAcceptanceFilter(short firstAcceptID, short lastAcceptID)
    {
        FirstAcceptID = (short)(firstAcceptID & 0x7ff);
        LastAcceptID = (short)(lastAcceptID & 0x7ff);
    }
}
