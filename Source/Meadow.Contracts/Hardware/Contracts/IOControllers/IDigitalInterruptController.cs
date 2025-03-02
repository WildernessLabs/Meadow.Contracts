using System;
namespace Meadow.Hardware
{
    /// <summary>
    /// Contract for IO devices that are capable of creating `IDigitalInterruptPort`
    /// instances.
    /// </summary>
    public interface IDigitalInterruptController : IPinController
    {
        /// <summary>
        /// Creates an IDigitalInterruptPort on the specified pin.
        /// </summary>
        /// <param name="pin">The pin on which to create the port.</param>
        /// <param name="interruptMode">An `InterruptMode` describing whether or
        /// not the port should be notify on change, and what type of change to
        /// notify on.</param>
        /// <param name="resistorMode">The `ResistorMode` specifying whether an
        /// external pull-up/pull-down resistor is used, or an internal pull-up/pull-down
        /// resistor should be configured for default state.</param>
        /// <param name="debounceDuration">The duration, with microseconds (µs) resolution,
        /// of the time to ignore state changes _after_ a deliberate state change
        /// has occurred. Used to prevent unwanted state changes due to noise.
        /// Set to `0` if no debounce filter is required.</param>
        /// <param name="glitchDuration">The minimum duration, with microseconds
        /// (µs) resolution, of an initial state change to persist before it's notified as
        /// an intentional state change, rather than a spurious one. Use this to
        /// ensure that noise doesn't trigger an in interrupt.</param>
        IDigitalInterruptPort CreateDigitalInterruptPort(
            IPin pin,
            InterruptMode interruptMode,
            ResistorMode resistorMode,
            TimeSpan debounceDuration,
            TimeSpan glitchDuration
            );

        /// <summary>
        /// Creates an IDigitalInterruptPort on the specified pin.
        /// </summary>
        /// <param name="pin">The pin on which to create the port.</param>
        /// <param name="interruptMode">An `InterruptMode` describing whether or
        /// not the port should be notify on change, and what type of change to
        /// notify on.</param>
        public IDigitalInterruptPort CreateDigitalInterruptPort(
            IPin pin,
            InterruptMode interruptMode
            )
        {
            return CreateDigitalInterruptPort(pin, interruptMode, ResistorMode.Disabled, TimeSpan.Zero, TimeSpan.Zero);
        }

        /// <summary>
        /// Creates an IDigitalInterruptPort on the specified pin.
        /// </summary>
        /// <param name="pin">The pin on which to create the port.</param>
        /// <param name="interruptMode">An `InterruptMode` describing whether or
        /// not the port should be notify on change, and what type of change to
        /// notify on.</param>
        /// <param name="resistorMode">The `ResistorMode` specifying whether an
        /// external pull-up/pull-down resistor is used, or an internal pull-up/pull-down
        /// resistor should be configured for default state.</param>
        public IDigitalInterruptPort CreateDigitalInterruptPort(
            IPin pin,
            InterruptMode interruptMode,
            ResistorMode resistorMode
            )
        {
            return CreateDigitalInterruptPort(pin, interruptMode, resistorMode, TimeSpan.Zero, TimeSpan.Zero);
        }

        /// <summary>
        /// Creates an IDigitalSignalAnalyzer on the specified pin
        /// </summary>
        /// <param name="pin">The pin on which to create the analyzer.</param>
        /// <param name="captureDutyCycle">Whether or not to capture duty cycle. Not capturing it is more efficient and allows faster frequency capture</param>
        public IDigitalSignalAnalyzer CreateDigitalSignalAnalyzer(IPin pin, bool captureDutyCycle);
    }
}