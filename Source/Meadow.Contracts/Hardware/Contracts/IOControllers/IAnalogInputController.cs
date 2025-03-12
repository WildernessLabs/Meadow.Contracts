using Meadow.Units;
using System;

namespace Meadow.Hardware;

/// <summary>
/// Contract for devices that expose `IAnalogInputPort(s)`.
/// </summary>
public interface IAnalogInputController : IPinController
{
    // TODO: if Microsoft ever gets around to fixing the compile time const
    // thing, we should make this a `Voltage` 
    /// <summary>
    /// The default Analog to Digital converter reference voltage.
    /// </summary>
    const float DefaultA2DReferenceVoltage = 3.3f;

    /// <summary>
    /// Initializes the specified pin to be an AnalogInput and returns the
    /// port used to sample the port value.
    /// </summary>
    /// <param name="pin">The pin to create the port on.</param>
    /// <param name="sampleCount">The number of samples to use for input averaging</param>
    /// <returns></returns>
    IAnalogInputPort CreateAnalogInputPort(
        IPin pin,
        int sampleCount
    ) => CreateAnalogInputPort(pin, sampleCount, TimeSpan.FromSeconds(1), new Voltage(DefaultA2DReferenceVoltage, Voltage.UnitType.Volts));

    /// <summary>
    /// Initializes the specified pin to be an AnalogInput and returns the
    /// port used to sample the port value.
    /// </summary>
    /// <param name="pin">The pin to create the port on.</param>
    /// <param name="sampleCount">The number of samples to use for input averaging</param>
    /// <param name="sampleInterval">The interval between readings</param>
    IAnalogInputPort CreateAnalogInputPort(
        IPin pin,
        int sampleCount,
        TimeSpan sampleInterval
    ) => CreateAnalogInputPort(pin, sampleCount, sampleInterval, new Voltage(DefaultA2DReferenceVoltage, Voltage.UnitType.Volts));

    /// <summary>
    /// Initializes the specified pin to be an AnalogInput and returns the
    /// port used to sample the port value.
    /// </summary>
    /// <param name="pin">The pin to create the port on.</param>
    /// <param name="sampleCount">The number of samples to use for input averaging</param>
    /// <param name="sampleInterval">The interval between readings</param>
    /// <param name="voltageReference">Reference maximum analog input port
    /// voltage in Volts. Default is 3.3V.</param>
    IAnalogInputPort CreateAnalogInputPort(
        IPin pin,
        int sampleCount,
        TimeSpan sampleInterval,
        Voltage voltageReference
    );

    /// <summary>
    /// Creates an IAnalogInputArray instance from the specified set of pins
    /// </summary>
    /// <param name="pins">The pins to use for the IAnalogInputArray</param>
    IAnalogInputArray CreateAnalogInputArray(params IPin[] pins);

    /// <summary>
    /// Initializes the specified pin to be an AnalogInput and returns the
    /// port used to sample the port value.
    /// </summary>
    /// <param name="pin">The pin to create the port on.</param>
    /// <param name="sampleCount">The number of samples to use for input averaging</param>
    /// <param name="sampleInterval">The interval between readings</param>
    /// <param name="voltageReference">Reference maximum analog input port
    /// voltage in Volts. Default is 3.3V.</param>
    IObservableAnalogInputPort CreateObservableAnalogInputPort(
        IPin pin,
        int sampleCount,
        TimeSpan sampleInterval,
        Voltage voltageReference
    );

}
