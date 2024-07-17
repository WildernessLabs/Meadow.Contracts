using System;

namespace Meadow;

/// <summary>
/// Contains information about a Meadow Cloud system error
/// </summary>
public class MeadowCloudSystemErrorInfo : MeadowSystemErrorInfo
{
    /// <summary>
    /// Creates a MeadowCloudSystemErrorInfo object
    /// </summary>
    /// <param name="exception">The exception from Meadow Cloud</param>
    public MeadowCloudSystemErrorInfo(Exception exception)
        : base("Meadow Cloud Error", SystemErrorNumber.MeadowCloudError, exception)
    {
    }
}
