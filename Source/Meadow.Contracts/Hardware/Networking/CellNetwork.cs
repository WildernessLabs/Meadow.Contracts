﻿namespace Meadow.Networking;

public record CellNetwork
{
    public string Status { get; set; }
    public string Name { get; set; }
    public string Operator { get; set; }
    public string Code { get; set; }
    public string Mode { get; set; }
}
