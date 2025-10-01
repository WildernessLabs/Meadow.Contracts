namespace Meadow.Cloud;

/// <summary>
/// Priority levels for cloud telemetry
/// </summary>
public enum CloudTelemetryPriority
{
    /// <summary>
    /// High priority - errors, critical events (sent first)
    /// </summary>
    High = 0,

    /// <summary>
    /// Normal priority - regular telemetry (default)
    /// </summary>
    Normal = 1,

    /// <summary>
    /// Low priority - verbose logging, diagnostics (sent last)
    /// </summary>
    Low = 2
}
