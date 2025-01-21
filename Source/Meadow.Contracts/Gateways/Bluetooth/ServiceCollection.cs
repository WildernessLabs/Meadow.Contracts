using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Meadow.Gateways.Bluetooth
{
    /// <summary>
    /// Represents a collection of Bluetooth services.
    /// </summary>
    public class ServiceCollection : IEnumerable<IService>
    {
        private readonly Dictionary<string, IService> m_services = new(StringComparer.InvariantCultureIgnoreCase);

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCollection"/> class.
        /// </summary>
        public ServiceCollection()
        {
        }

        /// <summary>
        /// Gets the number of services in the collection.
        /// </summary>
        public int Count
        {
            get => m_services.Count;
        }

        /// <summary>
        /// Adds a service to the collection.
        /// </summary>
        /// <param name="service">The service to add.</param>
        public void Add(IService service)
        {
            m_services.Add(service.Name, service);
        }

        /// <summary>
        /// Adds a range of services to the collection.
        /// </summary>
        /// <param name="services">The services to add.</param>
        public void AddRange(IEnumerable<IService> services)
        {
            foreach (var s in services)
            {
                Add(s);
            }
        }

        /// <summary>
        /// Clear the Service Collection.
        /// </summary> 
        public void Clear()
        {
            m_services.Clear();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<IService> GetEnumerator()
        {
            return m_services.Values.GetEnumerator();
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
        /// Gets the service with the specified name.
        /// </summary>
        /// <param name="serviceName">The name of the service to retrieve.</param>
        /// <returns>The service with the specified name; or <c>null</c> if not found.</returns>
        public IService? this[string serviceName]
        {
            get => m_services.ContainsKey(serviceName) ? m_services[serviceName] : null;
        }

        /// <summary>
        /// Gets the service at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the service to retrieve.</param>
        /// <returns>The service at the specified index.</returns>
        public IService? this[int index]
        {
            get => m_services.Values.ElementAt(index);
        }
    }
}