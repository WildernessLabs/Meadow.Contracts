using Meadow.Units;
using System;
using System.Linq;

namespace Meadow.Hardware
{
    /// <summary>
    /// Extension methods for the IPin interface
    /// </summary>
    public static class IPinExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TChannel"></typeparam>
        /// <param name="pin"></param>
        /// <example>pin.Supports&lt;IIPwmChannelInfo&gt;();</example>
        /// <returns></returns>
        public static bool Supports<TChannel>(this IPin pin)
            where TChannel : IChannelInfo
        {
            var chan = pin.SupportedChannels.OfType<TChannel>().FirstOrDefault();
            return chan != null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TChannel"></typeparam>
        /// <param name="pin"></param>
        /// <param name="where"></param>
        /// <example>pin.Supports&lt;IDigitalChannelInfo&gt;(c =&gt; c.OutputCapable);</example>
        /// <returns></returns>
        public static bool Supports<TChannel>(this IPin pin, Func<TChannel, bool> where)
            where TChannel : IChannelInfo
        {
            var chan = pin.SupportedChannels.OfType<TChannel>().Where(where).FirstOrDefault();
            return chan != null;
        }

        /// <summary>
        /// Creates an IDigitalOutputPort on a capable IPin
        /// </summary>
        /// <param name="pin">The source pin</param>
        /// <param name="initialState">Initial state of the port</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IDigitalOutputPort CreateDigitalOutputPort(this IPin pin, bool initialState = false)
        {
            if (pin.Controller is IDigitalOutputController controller)
            {
                return controller.CreateDigitalOutputPort(pin, initialState);
            }

            throw new ArgumentException("Pin is not digital output capable");
        }

        /// <summary>
        /// Creates an IDigitalInputPort on a capable IPin
        /// </summary>
        /// <param name="pin">The source pin</param>
        /// <param name="interruptMode"></param>
        /// <param name="resistorMode"></param>
        /// <param name="debounceDuration"></param>
        /// <param name="glitchDuration"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IDigitalInterruptPort CreateDigitalInterruptPort(this IPin pin, InterruptMode interruptMode, ResistorMode resistorMode, TimeSpan debounceDuration, TimeSpan glitchDuration)
        {
            if (pin.Controller is IDigitalInterruptController controller)
            {
                return controller.CreateDigitalInterruptPort(pin, interruptMode, resistorMode, debounceDuration, glitchDuration);
            }

            throw new ArgumentException("Pin is not digital input capable");
        }

        /// <summary>
        /// Creates an IDigitalInputPort on a capable IPin
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="resistorMode"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IDigitalInputPort CreateDigitalInputPort(this IPin pin, ResistorMode resistorMode = ResistorMode.Disabled)
        {
            if (pin.Controller is IDigitalInputController controller)
            {
                return controller.CreateDigitalInputPort(pin, resistorMode);
            }

            throw new ArgumentException("Pin is not digital input capable");
        }

        /// <summary>
        /// Creates an IDigitalInputPort on a capable IPin
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="interruptMode"></param>
        /// <param name="resistorMode"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IDigitalInterruptPort CreateDigitalInterruptPort(this IPin pin, InterruptMode interruptMode, ResistorMode resistorMode = ResistorMode.Disabled)
        {
            if (pin.Controller is IDigitalInterruptController controller)
            {
                return controller.CreateDigitalInterruptPort(pin, interruptMode, resistorMode, TimeSpan.Zero, TimeSpan.Zero);
            }

            throw new ArgumentException($"Pin '{pin.Name}' is not digital interrupt capable");
        }

        /// <summary>
        /// Creates an IAnalogInputPort on a capable IPin
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="sampleCount"></param>
        /// <param name="sampleInterval"></param>
        /// <param name="referenceVoltage"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IAnalogInputPort CreateAnalogInputPort(this IPin pin, int sampleCount, TimeSpan sampleInterval, Units.Voltage referenceVoltage)
        {
            if (pin.Controller is IAnalogInputController controller)
            {
                return controller.CreateAnalogInputPort(pin, sampleCount, sampleInterval, referenceVoltage);
            }

            throw new ArgumentException("Pin is not analog input capable");
        }

        /// <summary>
        /// Creates an IAnalogInputPort on a capable IPin
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="sampleCount"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IAnalogInputPort CreateAnalogInputPort(this IPin pin, int sampleCount = 1)
        {
            if (pin.Controller is IAnalogInputController controller)
            {
                return controller.CreateAnalogInputPort(pin, sampleCount);
            }

            throw new ArgumentException("Pin is not analog input capable");
        }

        /// <summary>
        /// Creates an IPwmPort on a capable IPin
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="frequency"></param>
        /// <param name="dutyCycle"></param>
        /// <param name="invert"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IPwmPort CreatePwmPort(this IPin pin, Frequency frequency, float dutyCycle = 0.5f, bool invert = false)
        {
            if (pin.Controller is IPwmOutputController controller)
            {
                return controller.CreatePwmPort(pin, frequency, dutyCycle, invert);
            }

            throw new ArgumentException("Pin is not PWM output capable");
        }

        /// <summary>
        /// Creates an IBiDirectionalPort on a capable IPin
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="initialState"></param>
        /// <param name="interruptMode"></param>
        /// <param name="resistorMode"></param>
        /// <param name="initialDirection"></param>
        /// <param name="debounceDuration"></param>
        /// <param name="glitchDuration"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IBiDirectionalInterruptPort CreateBiDirectionalPort(this IPin pin, bool initialState, InterruptMode interruptMode, ResistorMode resistorMode, PortDirectionType initialDirection, TimeSpan debounceDuration, TimeSpan glitchDuration)
        {
            if (pin.Controller is IBiDirectionalController controller)
            {
                return controller.CreateBiDirectionalInterruptPort(pin, initialState, interruptMode, resistorMode, initialDirection, debounceDuration, glitchDuration);
            }

            throw new ArgumentException("Pin controller is not an IBiDirectionalController");
        }

        /// <summary>
        /// Creates an IBiDirectionalPort on a capable IPin
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="initialState"></param>
        /// <param name="interruptMode"></param>
        /// <param name="resistorMode"></param>
        /// <param name="initialDirection"></param>
        /// <returns></returns>
        public static IBiDirectionalInterruptPort CreateBiDirectionalPort(this IPin pin, bool initialState = false, InterruptMode interruptMode = InterruptMode.None, ResistorMode resistorMode = ResistorMode.Disabled, PortDirectionType initialDirection = PortDirectionType.Input)
        {
            return pin.CreateBiDirectionalPort(initialState, interruptMode, resistorMode, initialDirection, TimeSpan.Zero, TimeSpan.Zero);
        }
    }
}
