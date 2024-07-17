using System.Collections;
using System.Collections.Generic;

namespace Meadow.Hardware;

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
