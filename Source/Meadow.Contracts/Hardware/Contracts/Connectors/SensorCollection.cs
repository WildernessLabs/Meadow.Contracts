using Meadow.Peripherals.Sensors;
using System.Collections;
using System.Collections.Generic;

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
