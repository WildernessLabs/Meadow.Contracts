using Meadow.Peripherals.Sensors;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Meadow.Hardware;

/// <summary>
/// Represents a Collection of ISensors
/// </summary>
public class SensorCollection : IEnumerable<ISensor>
{
    /// <inheritdoc/>
    public IEnumerator<ISensor> GetEnumerator()
    {
        throw new System.NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new System.NotImplementedException();
    }
}

/// <summary>
/// Represents a Collection of IConnectors
/// </summary>
public class ConnectorCollection : IEnumerable<IConnector>
{
    private List<IConnector> _connectors = new();

    /// <summary>
    /// Creates a new ConnectorCollection
    /// </summary>
    protected ConnectorCollection() { }

    /// <inheritdoc/>
    public IEnumerator<IConnector> GetEnumerator()
    {
        return _connectors.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    /// <summary>
    /// Adds a connector to the collection
    /// </summary>
    /// <param name="connector">The Connector instance to add</param>
    protected void Add(IConnector connector)
    {
        _connectors.Add(connector);
    }

    /// <summary>
    /// Retrieves an empty ConnectorCollection
    /// </summary>
    public static ConnectorCollection Empty
    {
        get => new ConnectorCollection();
    }
}


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
