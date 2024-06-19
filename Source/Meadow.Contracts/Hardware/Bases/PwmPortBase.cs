﻿using Meadow.Units;
using System;

namespace Meadow.Hardware;

/// <summary>
/// Represents a base class for PWM ports.
/// </summary>
public abstract class PwmPortBase : DigitalPortBase, IPwmPort
{
    /// <summary>
    /// Gets or sets the PWM channel information associated with the port.
    /// </summary>
    public new IPwmChannelInfo Channel
    {
        get => (IPwmChannelInfo)base.Channel;
        protected set { base.Channel = value; }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PwmPortBase"/> class.
    /// </summary>
    /// <param name="pin">The pin associated with the PWM port.</param>
    /// <param name="channel">The PWM channel information for the port.</param>
    /// <param name="frequency">The PWM frequency.</param>
    /// <param name="dutyCycle">The initial PWM duty cycle (default is 0).</param>
    /// <param name="inverted">A value indicating whether the PWM signal is inverted (default is false).</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="pin"/> or <paramref name="channel"/> is <c>null</c>.</exception>
    protected PwmPortBase(
        IPin pin,
        IPwmChannelInfo channel,
        Frequency frequency,
        float dutyCycle = 0,
        bool inverted = false
        ) : base(pin, channel)
    {
        Inverted = inverted;
        Frequency = frequency;
        DutyCycle = dutyCycle;
    }

    /// <summary>
    /// Gets or sets a value indicating whether the PWM signal is inverted.
    /// </summary>
    public abstract bool Inverted { get; set; }

    /// <summary>
    /// Gets or sets the duty cycle of the PWM signal.
    /// </summary>
    public abstract float DutyCycle { get; set; }

    /// <summary>
    /// Gets or sets the frequency of the PWM signal.
    /// </summary>
    public abstract Frequency Frequency { get; set; }

    /// <summary>
    /// Gets or sets the duration of the PWM pulse.
    /// </summary>
    public abstract TimeSpan Duration { get; set; }

    /// <summary>
    /// Gets or sets the period of the PWM signal.
    /// </summary>
    public abstract float Period { get; set; }

    /// <summary>
    /// Gets the state of the PWM signal.
    /// </summary>
    public abstract bool State { get; }

    /// <summary>
    /// Starts the PWM signal.
    /// </summary>
    public abstract void Start();

    /// <summary>
    /// Stops the PWM signal.
    /// </summary>
    public abstract void Stop();
}
