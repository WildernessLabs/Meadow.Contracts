using System.Linq;

namespace Meadow.Hardware;

/// <summary>
/// Represents a Collection of IPins
/// </summary>
/// <typeparam name="TPinDefinition"></typeparam>
public abstract class Connector<TPinDefinition> : IConnector, IIOController<TPinDefinition>
    where TPinDefinition : IPinDefinitions
{
    /// <inheritdoc/>
    public string Name { get; }
    /// <inheritdoc/>
    public TPinDefinition Pins { get; }
    IPinDefinitions IConnector.Pins => Pins;

    /// <summary>
    /// Creates a Connector
    /// </summary>
    /// <param name="name">The connector name</param>
    /// <param name="pins">The pins in the connector</param>
    protected Connector(string name, TPinDefinition pins)
    {
        Name = name;
        Pins = pins;
    }

    /// <summary>
    /// Retrieves a pin by Name or Key
    /// </summary>
    /// <param name="pinName"></param>
    /// <returns></returns>
    public IPin? GetPin(string pinName)
    {
        return Pins.AllPins.FirstOrDefault(p => p.Name == pinName || p.Key.ToString() == p.Name);
    }
}
