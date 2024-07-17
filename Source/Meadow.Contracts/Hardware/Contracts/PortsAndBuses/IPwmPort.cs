using Meadow.Units;

namespace Meadow.Hardware
{
    /// <summary>
    /// Contract for a Port that has is capable of 
    /// </summary>
    public interface IPwmPort : IDigitalPort
    {
        /// <summary>
        /// PWM channel value
        /// </summary>
        new IPwmChannelInfo Channel { get; }

        /// <summary>
        /// Starts the PWM square wave output
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the PWM square wave output
        /// </summary>
        void Stop();

        /// <summary>
        /// Duration of pulse
        /// </summary>
        TimePeriod Duration { get; set; }

        /// <summary>
        /// Period of pulse
        /// </summary>
        TimePeriod Period { get; set; }

        /// <summary>
        /// Duty cycle (from 1 to 1.0)
        /// </summary>
        double DutyCycle { get; set; }

        /// <summary>
        /// Frequency 
        /// </summary>
        Frequency Frequency { get; set; }

        /// <summary>
        /// Is PWM signal inverted
        /// </summary>
        bool Inverted { get; set; }

        /// <summary>
        /// Is running
        /// </summary>
        bool State { get; }
    }
}
