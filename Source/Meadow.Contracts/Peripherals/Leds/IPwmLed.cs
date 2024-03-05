using System;
using System.Threading.Tasks;

namespace Meadow.Peripherals.Leds;

/// <summary>
/// Defines a Light Emitting Diode (LED) controlled by a pulse-width-modulation
/// (PWM) signal to limit current.
/// </summary>
public interface IPwmLed
{
    /// <summary>
    /// Gets or sets a value indicating whether the LED is on.
    /// </summary>
    /// <value><c>true</c> if is on; otherwise, <c>false</c>.</value>
    bool IsOn { get; set; }

    /// <summary>
    /// Gets the brightness of the LED, controlled by a PWM signal
    /// </summary>
    float Brightness { get; }

    /// <summary>
    /// Start a Blink animation which sets the brightness of the LED alternating between a low and high brightness setting.
    /// </summary>
    Task StartBlink(float highBrightness = 1f, float lowBrightness = 0f);

    /// <summary>
    /// Start the Blink animation which sets the brightness of the LED alternating between a low and high brightness setting, using the durations provided.
    /// </summary>
    Task StartBlink(TimeSpan highBrightnessDuration, TimeSpan lowBrightnessDuration, float highBrightness = 1f, float lowBrightness = 0f);

    /// <summary>
    /// Start the Pulse animation which gradually alternates the brightness of the LED between a low and high brightness setting.
    /// </summary>
    Task StartPulse(float highBrightness = 1, float lowBrightness = 0.15F);

    /// <summary>
    /// Start the Pulse animation which gradually alternates the brightness of the LED between a low and high brightness setting, using the durations provided.
    /// </summary>
    Task StartPulse(TimeSpan pulseDuration, float highBrightness = 1, float lowBrightness = 0.15F);

    /// <summary>
    /// Sets the LED to a specific brightness.
    /// </summary>
    void SetBrightness(float brightness);

    /// <summary>
    /// Stops any running animations.
    /// </summary>
    Task StopAnimation();
}