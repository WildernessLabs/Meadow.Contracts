using System;

namespace Meadow.Hardware
{
    /// <summary>
    /// Contract for ports that are capable of reading digital inputs and raising
    /// events when state changes.
    /// </summary>
    public interface IDigitalInterruptPort : IDigitalInputPort, IObservable<IChangeResult<DigitalState>>
    {
        //TODO: should this be `Updated`?
        /// <summary>
        /// Raised when the state of the digital port is changed / updated.
        /// </summary>
        event EventHandler<DigitalPortResult> Changed;

        /// <summary>
        /// Gets the interrupt mode used to determine when interrupts are raised.
        /// </summary>
        InterruptMode InterruptMode { get; }

        /// <summary>
        /// Gets or sets the debounce duration.
        /// Effectively a delay after an event where new inputs are ignored
        /// </summary>
        TimeSpan DebounceDuration { get; set; }

        /// <summary>
        /// Gets or sets the glitch duration. 
        /// This is the minimum amount of time a signal needs to be stable before an event is recognized
        /// </summary>
        TimeSpan GlitchDuration { get; set; }

        /// <inheritdoc cref="FilterableChangeObserver{UNIT}"/>
        public static FilterableChangeObserver<DigitalState>
            CreateObserver(
                Action<IChangeResult<DigitalState>> handler,
                Predicate<IChangeResult<DigitalState>>? filter = null)
        {
            return new FilterableChangeObserver<DigitalState>(
                handler, filter);
        }
    }
}
