namespace Meadow.Hardware;

/// <summary>
/// Represents a base class for CAN acceptance filters.
/// </summary>
public abstract class CanAcceptanceFilter
{
    /// <summary>
    /// Creates a standard exact acceptance filter for the specified identifier.
    /// </summary>
    /// <param name="id">The identifier to be accepted by the filter.</param>
    /// <returns>A <see cref="CanStandardExactAcceptanceFilter"/> instance.</returns>
    public static CanAcceptanceFilter CreateStandardFilter(short id)
    {
        return new CanStandardExactAcceptanceFilter(id);
    }

    /// <summary>
    /// Creates a standard range acceptance filter for the specified range of identifiers.
    /// </summary>
    /// <param name="firstID">The first identifier in the range to be accepted by the filter.</param>
    /// <param name="lastID">The last identifier in the range to be accepted by the filter.</param>
    /// <returns>A <see cref="CanStandardRangeAcceptanceFilter"/> instance.</returns>
    public static CanAcceptanceFilter CreateStandardFilter(short firstID, short lastID)
    {
        return new CanStandardRangeAcceptanceFilter(firstID, lastID);
    }
}
