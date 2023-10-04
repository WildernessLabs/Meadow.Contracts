﻿namespace Meadow.Networking;

/// <summary>
/// Describes properties of a Cell network
/// </summary>
public record CellNetwork
{
    /// <summary>
    /// Gets or set the network status
    /// </summary>
    public CellNetworkStatus Status { get; set; } = default!;
    /// <summary>
    /// Gets or set the network name
    /// </summary>
    public string Name { get; set; } = default!;
    /// <summary>
    /// Gets or set the network operator
    /// </summary>
    public string Operator { get; set; } = default!;
    /// <summary>
    /// Gets or set the network code
    /// </summary>
    public string Code { get; set; } = default!;
    /// <summary>
    /// Gets or set the network mode
    /// </summary>
    public CellNetworkMode Mode { get; set; } = default!;
}
