using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Meadow.Hardware;

/// <summary>
/// Represents a collection of CAN acceptance filters.
/// </summary>
public sealed class CanAcceptanceFilterCollection
{
    /// <summary>
    /// Occurs when the collection is changed.
    /// </summary>
    public event EventHandler<(CollectionChangeAction Action, CanAcceptanceFilter Filter)>? CollectionChanged;

    private List<CanAcceptanceFilter> _filters = new();

    /// <summary>
    /// Gets the maximum number of filters that can be contained in the collection.
    /// </summary>
    public int MaxFilterCount { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CanAcceptanceFilterCollection"/> class with the specified maximum number of filters.
    /// </summary>
    /// <param name="maxFilterCount">The maximum number of filters that the collection can contain.</param>
    public CanAcceptanceFilterCollection(int maxFilterCount)
    {
        MaxFilterCount = maxFilterCount;
    }

    /// <summary>
    /// Gets the filter at the specified index.
    /// </summary>
    /// <param name="index">The zero-based index of the filter to get.</param>
    /// <returns>The filter at the specified index.</returns>
    public CanAcceptanceFilter this[int index]
    {
        get
        {
            lock (_filters)
            {
                return _filters[index];
            }
        }
    }

    /// <summary>
    /// Gets the count of filters in the collection
    /// </summary>
    public int Count
    {
        get
        {
            lock (_filters)
            {
                return _filters.Count;
            }
        }
    }

    /// <summary>
    /// Removes all filters from the collection.
    /// </summary>
    public void Clear()
    {
        lock (_filters)
        {
            foreach (var f in _filters.ToList())
            {
                Remove(f);
            }
        }
    }

    /// <summary>
    /// Adds a filter to the collection.
    /// </summary>
    /// <param name="filter">The filter to add.</param>
    public void Add(CanAcceptanceFilter filter)
    {
        lock (_filters)
        {
            if (_filters.Count >= MaxFilterCount)
            {
                throw new ArgumentOutOfRangeException($"Maximum filter count of {MaxFilterCount} has been reached");
            }

            _filters.Add(filter);
        }

        CollectionChanged?.Invoke(this, new(CollectionChangeAction.Add, filter));
    }

    /// <summary>
    /// Removes a filter from the collection.
    /// </summary>
    /// <param name="filter">The filter to remove.</param>
    public void Remove(CanAcceptanceFilter filter)
    {
        lock (_filters)
        {
            _filters.Remove(filter);
        }
        CollectionChanged?.Invoke(this, new(CollectionChangeAction.Remove, filter));
    }
}
