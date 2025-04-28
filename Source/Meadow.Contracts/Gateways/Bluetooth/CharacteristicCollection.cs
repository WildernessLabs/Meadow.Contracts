using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Meadow.Gateways.Bluetooth
{
    /// <summary>
    /// Represents a collection of characteristics.
    /// </summary>
    public class CharacteristicCollection : IEnumerable<ICharacteristic>
    {
        private readonly Dictionary<string, ICharacteristic> m_characteristics = new Dictionary<string, ICharacteristic>(StringComparer.InvariantCultureIgnoreCase);

        /// <summary>
        /// Initializes a new instance of the <see cref="CharacteristicCollection"/> class.
        /// </summary>
        public CharacteristicCollection()
        {
        }

        /// <summary>
        /// Gets the number of characteristics in the collection.
        /// </summary>
        public int Count
        {
            get => m_characteristics.Count;
        }

        /// <summary>
        /// Adds a characteristic to the collection.
        /// </summary>
        /// <param name="characteristic">The characteristic to add.</param>
        public void Add(ICharacteristic characteristic)
        {
            m_characteristics.Add(characteristic.Name, characteristic);
        }

        /// <summary>
        /// Adds a range of characteristics to the collection.
        /// </summary>
        /// <param name="characteristics">The characteristics to add.</param>
        public void AddRange(IEnumerable<ICharacteristic> characteristics)
        {
            foreach (var c in characteristics)
            {
                Add(c);
            }
        }

        /// <summary>
        /// Clear the characteristicCollection.
        /// </summary>
        public void Clear()
        {
            m_characteristics.Clear();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<ICharacteristic> GetEnumerator()
        {
            return m_characteristics.Values.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Gets the characteristic with the specified name or UUID.
        /// </summary>
        /// <param name="nameOrId">The name or UUID of the characteristic to retrieve.</param>
        /// <returns>The characteristic with the specified name or UUID; or <c>null</c> if not found.</returns>
        public ICharacteristic? this[string nameOrId]
        {
            get
            {
                if (m_characteristics.ContainsKey(nameOrId))
                {
                    return m_characteristics[nameOrId];
                }

                return m_characteristics.Values.FirstOrDefault(c => string.Compare(c.Uuid, nameOrId, true) == 0);
            }
        }

        /// <summary>
        /// Gets the characteristic at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the characteristic to retrieve.</param>
        /// <returns>The characteristic at the specified index.</returns>
        public ICharacteristic? this[int index]
        {
            get => m_characteristics.Values.ElementAt(index);
        }
    }
}
