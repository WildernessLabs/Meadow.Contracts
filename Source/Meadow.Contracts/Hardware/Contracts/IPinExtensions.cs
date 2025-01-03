using Meadow.Hardware;
using Meadow.Units;
using System;
using System.Linq;

namespace Meadow;

/// <summary>
/// Extension methods for the IPin interface
/// </summary>
public static class IPinExtensions
{
    /// <summary>
    /// Checks if the pin supports the specified channel type.
    /// </summary>
    /// <typeparam name="TChannel">The type of channel to check for.</typeparam>
    /// <param name="pin">The pin to check.</param>
    /// <returns>True if the pin supports the specified channel type; otherwise, false.</returns>
    /// <example>pin.Supports&lt;IIPwmChannelInfo&gt;();</example>
    public static bool Supports<TChannel>(this IPin pin)
        where TChannel : IChannelInfo
    {
        var chan = pin.SupportedChannels.OfType<TChannel>().FirstOrDefault();
        return chan != null;
    }

    /// <summary>
    /// Checks if the pin supports the specified channel type based on a condition.
    /// </summary>
    /// <typeparam name="TChannel">The type of channel to check for.</typeparam>
    /// <param name="pin">The pin to check.</param>
    /// <param name="where">The condition to apply.</param>
    /// <returns>True if the pin supports the specified channel type based on the condition; otherwise, false.</returns>
    /// <example>pin.Supports&lt;IDigitalChannelInfo&gt;(c =&gt; c.OutputCapable);</example>
    public static bool Supports<TChannel>(this IPin pin, Func<TChannel, bool> where)
        where TChannel : IChannelInfo
    {
        var chan = pin.SupportedChannels.OfType<TChannel>().Where(where).FirstOrDefault();
        return chan != null;
    }

    /// <summary>
    /// Creates a digital output port for the specified pin.
    /// </summary>
    /// <param name="pin">The pin to create a digital output port for.</param>
    /// <param name="initialState">The initial state of the digital output port (default is false).</param>
    /// <returns>The created digital output port.</returns>
    public static IDigitalOutputPort CreateDigitalOutputPort(this IPin pin, bool initialState = false)
    {
        if (pin.Controller is IDigitalOutputController controller)
        {
            return controller.CreateDigitalOutputPort(pin, initialState);
        }

        throw new ArgumentException("Pin is not digital output capable");
    }

    /// <summary>
    /// Creates a digital signal analyzer for the specified pin.
    /// </summary>
    /// <param name="pin">The pin to create a digital signal analyzer for.</param>
    /// <param name="captureDutyCycle">Whether or not to capture duty cycle. Not capturing it is more efficient and allows faster frequency capture</param>
    /// <returns>The created digital signal analyzer.</returns>
    public static IDigitalSignalAnalyzer CreateDigitalSignalAnalyzer(this IPin pin, bool captureDutyCycle)
    {
        if (pin.Controller is IDigitalInterruptController controller)
        {
            return controller.CreateDigitalSignalAnalyzer(pin, captureDutyCycle);
        }

        throw new ArgumentException("Pin is not interrupt capable");
    }

    /// <summary>
    /// Creates a digital interrupt port for the specified pin with specified configurations.
    /// </summary>
    /// <param name="pin">The pin to create a digital interrupt port for.</param>
    /// <param name="interruptMode">The interrupt mode for the digital interrupt port.</param>
    /// <param name="resistorMode">The resistor mode for the digital interrupt port.</param>
    /// <param name="debounceDuration">The debounce duration for the digital interrupt port.</param>
    /// <param name="glitchDuration">The glitch duration for the digital interrupt port.</param>
    /// <returns>The created digital interrupt port.</returns>
    public static IDigitalInterruptPort CreateDigitalInterruptPort(this IPin pin, InterruptMode interruptMode, ResistorMode resistorMode, TimeSpan debounceDuration, TimeSpan glitchDuration)
    {
        if (pin.Controller is IDigitalInterruptController controller)
        {
            return controller.CreateDigitalInterruptPort(pin, interruptMode, resistorMode, debounceDuration, glitchDuration);
        }

        throw new ArgumentException("Pin is not interrupt capable");
    }

    /// <summary>
    /// Creates a digital interrupt port for the specified pin with specified configurations.
    /// </summary>
    /// <param name="pin">The pin to create a digital interrupt port for.</param>
    /// <param name="interruptMode">The interrupt mode for the digital interrupt port.</param>
    /// <param name="resistorMode">The resistor mode for the digital interrupt port.</param>
    /// <param name="debounceDuration">The debounce duration for the digital interrupt port.</param>
    /// <returns>The created digital interrupt port.</returns>
    public static IDigitalInterruptPort CreateDigitalInterruptPort(this IPin pin, InterruptMode interruptMode, ResistorMode resistorMode, TimeSpan debounceDuration)
    {
        return pin.CreateDigitalInterruptPort(interruptMode, resistorMode, debounceDuration, TimeSpan.Zero);
    }

    /// <summary>
    /// Creates a digital input port for the specified pin with the specified resistor mode.
    /// </summary>
    /// <param name="pin">The pin to create a digital input port for.</param>
    /// <param name="resistorMode">The resistor mode for the digital input port (default is ResistorMode.Disabled).</param>
    /// <returns>The created digital input port.</returns>
    public static IDigitalInputPort CreateDigitalInputPort(this IPin pin, ResistorMode resistorMode = ResistorMode.Disabled)
    {
        if (pin.Controller is IDigitalInputController controller)
        {
            return controller.CreateDigitalInputPort(pin, resistorMode);
        }

        throw new ArgumentException("Pin is not digital input capable");
    }

    /// <summary>
    /// Creates a digital interrupt port for the specified pin with the specified configurations.
    /// </summary>
    /// <param name="pin">The pin to create a digital interrupt port for.</param>
    /// <param name="interruptMode">The interrupt mode for the digital interrupt port.</param>
    /// <param name="resistorMode">The resistor mode for the digital interrupt port (default is ResistorMode.Disabled).</param>
    /// <returns>The created digital interrupt port.</returns>
    public static IDigitalInterruptPort CreateDigitalInterruptPort(this IPin pin, InterruptMode interruptMode, ResistorMode resistorMode = ResistorMode.Disabled)
    {
        if (pin.Controller is IDigitalInterruptController controller)
        {
            return controller.CreateDigitalInterruptPort(pin, interruptMode, resistorMode, TimeSpan.Zero, TimeSpan.Zero);
        }

        throw new ArgumentException($"Pin '{pin.Name}' is not digital interrupt capable");
    }

    /// <summary>
    /// Creates an analog input port for the specified pin with the given sample count, sample interval, and reference voltage.
    /// </summary>
    /// <param name="pin">The pin to create an analog input port for.</param>
    /// <param name="sampleCount">The number of samples to take during each reading.</param>
    /// <param name="sampleInterval">The interval between each sample.</param>
    /// <param name="referenceVoltage">The reference voltage for the analog input port.</param>
    /// <returns>The created analog input port.</returns>
    public static IAnalogInputPort CreateAnalogInputPort(this IPin pin, int sampleCount, TimeSpan sampleInterval, Units.Voltage referenceVoltage)
    {
        if (pin.Controller is IAnalogInputController controller)
        {
            return controller.CreateAnalogInputPort(pin, sampleCount, sampleInterval, referenceVoltage);
        }

        throw new ArgumentException("Pin is not analog input capable");
    }

    /// <summary>
    /// Creates an analog input port for the specified pin with the default sample count and default settings.
    /// </summary>
    /// <param name="pin">The pin to create an analog input port for.</param>
    /// <param name="sampleCount">The number of samples to take during each reading (default is 5).</param>
    /// <returns>The created analog input port.</returns>
    public static IAnalogInputPort CreateAnalogInputPort(this IPin pin, int sampleCount = 5)
    {
        if (pin.Controller is IAnalogInputController controller)
        {
            return controller.CreateAnalogInputPort(pin, sampleCount);
        }

        throw new ArgumentException("Pin is not analog input capable");
    }

    /// <summary>
    /// Creates an analog output port for the specified pin.
    /// </summary>
    /// <param name="pin">The pin to create an analog output port for.</param>
    /// <returns>The created analog output port.</returns>
    public static IAnalogOutputPort CreateAnalogOutputPort(this IPin pin)
    {
        if (pin.Controller is IAnalogOutputController controller)
        {
            return controller.CreateAnalogOutputPort(pin);
        }

        throw new ArgumentException("Pin is not analog output capable");
    }

    /// <summary>
    /// Creates a PWM (Pulse Width Modulation) port for the specified pin with the given frequency, duty cycle, and inversion setting.
    /// </summary>
    /// <param name="pin">The pin to create a PWM port for.</param>
    /// <param name="frequency">The frequency of the PWM signal.</param>
    /// <param name="dutyCycle">The duty cycle of the PWM signal (default is 0.5).</param>
    /// <param name="invert">Whether to invert the PWM signal (default is false).</param>
    /// <returns>The created PWM port.</returns>
    public static IPwmPort CreatePwmPort(this IPin pin, Frequency frequency, float dutyCycle = 0.5f, bool invert = false)
    {
        if (pin.Controller is IPwmOutputController controller)
        {
            return controller.CreatePwmPort(pin, frequency, dutyCycle, invert);
        }

        throw new ArgumentException("Pin is not PWM output capable");
    }

    /// <summary>
    /// Creates a bidirectional interrupt port for the specified pin with the specified initial state, interrupt mode, resistor mode, initial direction, debounce duration, and glitch duration.
    /// </summary>
    /// <param name="pin">The pin to create a bidirectional interrupt port for.</param>
    /// <param name="initialState">The initial state of the port.</param>
    /// <param name="interruptMode">The interrupt mode for the port.</param>
    /// <param name="resistorMode">The resistor mode for the port.</param>
    /// <param name="initialDirection">The initial direction of the port.</param>
    /// <param name="debounceDuration">The debounce duration for the port.</param>
    /// <param name="glitchDuration">The glitch duration for the port.</param>
    /// <returns>The created bidirectional interrupt port.</returns>
    public static IBiDirectionalInterruptPort CreateBiDirectionalPort(this IPin pin, bool initialState, InterruptMode interruptMode, ResistorMode resistorMode, PortDirectionType initialDirection, TimeSpan debounceDuration, TimeSpan glitchDuration)
    {
        if (pin.Controller is IBiDirectionalController controller)
        {
            return controller.CreateBiDirectionalInterruptPort(pin, initialState, interruptMode, resistorMode, initialDirection, debounceDuration, glitchDuration);
        }

        throw new ArgumentException("Pin controller is not an IBiDirectionalController");
    }

    /// <summary>
    /// Creates a bidirectional interrupt port for the specified pin with default settings.
    /// </summary>
    /// <param name="pin">The pin to create a bidirectional interrupt port for.</param>
    /// <param name="initialState">The initial state of the port (default is false).</param>
    /// <param name="interruptMode">The interrupt mode for the port (default is InterruptMode.None).</param>
    /// <param name="resistorMode">The resistor mode for the port (default is ResistorMode.Disabled).</param>
    /// <param name="initialDirection">The initial direction of the port (default is PortDirectionType.Input).</param>
    /// <returns>The created bidirectional interrupt port.</returns>
    public static IBiDirectionalInterruptPort CreateBiDirectionalPort(this IPin pin, bool initialState = false, InterruptMode interruptMode = InterruptMode.None, ResistorMode resistorMode = ResistorMode.Disabled, PortDirectionType initialDirection = PortDirectionType.Input)
    {
        return pin.CreateBiDirectionalPort(initialState, interruptMode, resistorMode, initialDirection, TimeSpan.Zero, TimeSpan.Zero);
    }
}
