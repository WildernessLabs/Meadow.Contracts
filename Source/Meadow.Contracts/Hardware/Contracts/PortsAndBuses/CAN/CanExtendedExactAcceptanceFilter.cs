namespace Meadow.Hardware;

/// <summary>
/// Represents a CAN extended exact acceptance filter.
/// </summary>
public class CanExtendedExactAcceptanceFilter : CanAcceptanceFilter
{
    /// <summary>
    /// Gets the accepted identifier.
    /// </summary>
    public int AcceptID { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CanExtendedExactAcceptanceFilter"/> class with the specified accepted identifier.
    /// </summary>
    /// <param name="acceptID">The accepted identifier.</param>
    public CanExtendedExactAcceptanceFilter(short acceptID)
    {
        AcceptID = (short)(acceptID & 0x7ff);
    }
}
