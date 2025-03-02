namespace Meadow.Hardware;

/// <summary>
/// Represents a CAN standard exact acceptance filter.
/// </summary>
public class CanStandardExactAcceptanceFilter : CanAcceptanceFilter
{
    /// <summary>
    /// Gets the accepted identifier.
    /// </summary>
    public short AcceptID { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CanStandardExactAcceptanceFilter"/> class with the specified accepted identifier.
    /// </summary>
    /// <param name="acceptID">The accepted identifier.</param>
    public CanStandardExactAcceptanceFilter(short acceptID)
    {
        AcceptID = (short)(acceptID & 0x7ff);
    }
}
