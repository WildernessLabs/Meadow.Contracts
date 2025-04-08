using Meadow.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meadow.Hardware;

/// <summary>
/// Provides a base implementation for much of the common tasks of 
/// implementing IAnalogInputPort
/// </summary>
public abstract class AnalogInputPortBase : AnalogPortBase, IObservableAnalogInputPort
{
    /// <summary>
    /// Gets the internal synchronization object for the analog buffer
    /// </summary>
    protected object BufferSyncRoot { get; } = new object();

    /// <summary>
    /// Raised when the value of the reading changes.
    /// </summary>
    public event EventHandler<IChangeResult<Voltage>> Updated = default!;

    /// <summary>
    /// Gets the sample buffer. Make sure to call StartUpdating() before 
    /// use.
    /// </summary>
    /// <value>The sample buffer.</value>
    // TODO: make this a Memory<Voltage> if possible.
    public Voltage[] VoltageSampleBuffer { get; }

    /// <summary>
    /// A `TimeSpan` that specifies how long to
    /// wait between readings. This value influences how often `*Updated`
    /// events are raised and `IObservable` consumers are notified.
    /// </summary>
    public TimeSpan UpdateInterval { get; protected set; }

    /// <summary>
    /// Number of samples to take per reading. If > `1` then the port will
    /// take multiple readings and These are automatically averaged to
    /// reduce noise, a process known as _oversampling_.
    /// </summary>
    public int SampleCount { get; protected set; }

    /// <summary>
    /// Duration in between samples when oversampling.
    /// </summary>
    public TimeSpan SampleInterval { get; protected set; }

    /// <summary>
    /// The reference voltage being used for the ADC comparison
    /// </summary>
    public Voltage ReferenceVoltage { get; protected set; }

    private readonly double _voltsPerBit;

    /// <summary>
    /// Gets the average value of the values in the buffer. Use in conjunction
    /// with StartUpdating() for long-running analog sampling. For occasional
    /// sampling, use Read().
    /// </summary>
    /// <value>The average buffer value.</value>
    public virtual Voltage Voltage
    {
        get
        {
            //heh. may be a faster way to do this. 
            lock (BufferSyncRoot)
            {
                return new Voltage(VoltageSampleBuffer.Select(x => x.Volts).Sum() / VoltageSampleBuffer.Length, Voltage.UnitType.Volts);
            }
        }
    }

    /// <summary>
    /// A collection of state observers
    /// </summary>
    protected List<IObserver<IChangeResult<Voltage>>> Observers { get; private set; } = new List<IObserver<IChangeResult<Voltage>>>();

    /// <summary>
    /// Initializes a new instance of the <see cref="AnalogInputPortBase"/> class.
    /// </summary>
    /// <param name="pin">The pin associated with the analog input port.</param>
    /// <param name="channel">The channel information for the analog input port.</param>
    /// <param name="sampleCount">The number of samples to be taken during each reading.</param>
    /// <param name="sampleInterval">The time interval between samples during each reading.</param>
    /// <param name="referenceVoltage">The reference voltage used for analog-to-digital conversion.</param>
    protected AnalogInputPortBase(
        IPin pin, IAnalogChannelInfo channel,
        int sampleCount, TimeSpan sampleInterval,
        Voltage referenceVoltage)
        : base(pin, channel)
    {
        Pin = pin;
        SampleCount = sampleCount;
        VoltageSampleBuffer = new Voltage[SampleCount];
        SampleInterval = sampleInterval;
        ReferenceVoltage = referenceVoltage;

        _voltsPerBit = ReferenceVoltage.Volts / (Math.Pow(2, channel.Precision) - 1);
    }

    /// <summary>
    /// Converts a raw 32-bit reading to a scaled value in volts
    /// </summary>
    /// <param name="rawReading">The raw reading to convert</param>
    protected double ConvertReadingToVoltage(int rawReading)
    {
        return _voltsPerBit * rawReading;
    }

    /// <summary>
    /// Convenience method to get the current voltage. For frequent reads, use
    /// StartUpdating() and StopUpdating() in conjunction with the SampleBuffer.
    /// </summary>
    public abstract Task<Voltage> Read();

    /// <summary>
    /// Starts continuously sampling the analog port.
    ///
    /// This method also starts raising `Changed` events and IObservable
    /// subscribers getting notified. Use the `readIntervalDuration` parameter
    /// to specify how often events and notifications are raised/sent.
    /// </summary>
    public abstract void StartUpdating(TimeSpan? updateInterval);

    /// <summary>
    /// Stops sampling the analog port.
    /// </summary>
    public abstract void StopUpdating();

    /// <summary>
    /// Raises the Changed event and notifies the observers with the specified change result.
    /// </summary>
    /// <param name="changeResult">The change result to be passed to the event and observers.</param>
    protected void RaiseChangedAndNotify(IChangeResult<Voltage> changeResult)
    {
        Updated?.Invoke(this, changeResult);
        Observers.ForEach(x => x.OnNext(changeResult));
    }

    /// <summary>
    /// Subscribes an observer to receive notifications of voltage change.
    /// </summary>
    /// <param name="observer">The observer to subscribe.</param>
    /// <returns>An IDisposable object that can be used to unsubscribe from the observer.</returns>
    public IDisposable Subscribe(IObserver<IChangeResult<Voltage>> observer)
    {
        if (!Observers.Contains(observer)) Observers.Add(observer);
        return new Unsubscriber(Observers, observer);
    }

    private class Unsubscriber : IDisposable
    {
        private readonly List<IObserver<IChangeResult<Voltage>>> _observers;
        private readonly IObserver<IChangeResult<Voltage>> _observer;

        public Unsubscriber(List<IObserver<IChangeResult<Voltage>>> observers, IObserver<IChangeResult<Voltage>> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            if (!(_observer == null)) _observers.Remove(_observer);
        }
    }

}
