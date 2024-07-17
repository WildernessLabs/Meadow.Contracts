using System;
using System.Collections.Generic;

namespace Meadow.Hardware;

/// <summary>
/// A base class for IBiDirectionalInterruptPort implementations
/// </summary>
public abstract class BiDirectionalInterruptPortBase : BiDirectionalPortBase, IBiDirectionalInterruptPort, IDisposable
{
    private readonly List<Unsubscriber> _unsubscribers = new();

    /// <summary>
    /// Event raised when the port value changes
    /// </summary>
    public event EventHandler<DigitalPortResult> Changed = default!;

    /// <summary>
    /// Gets a list of port State observers
    /// </summary>
    protected List<IObserver<IChangeResult<DigitalState>>> Observers { get; private set; } = new List<IObserver<IChangeResult<DigitalState>>>();

    /// <summary>
    /// Gets or sets the debounce duration of the port
    /// </summary>
    public abstract TimeSpan DebounceDuration { get; set; }
    /// <summary>
    /// Gets or sets the glitch filter duration of the port
    /// </summary>
    public abstract TimeSpan GlitchDuration { get; set; }

    /// <summary>
    /// Gets or sets a value indicating the type of interrupt monitoring this input.
    /// </summary>
    /// <value><c>true</c> if interrupt enabled; otherwise, <c>false</c>.</value>
    public InterruptMode InterruptMode { get; protected set; }

    /// <summary>
    /// Constructor for the BiDirectionalPortBase
    /// </summary>
    /// <param name="pin">The pin associated with the port.</param>
    /// <param name="channel">The channel information for the port.</param>
    /// <param name="initialState">The initial state of the port.</param>
    /// <param name="interruptMode">The type of interrupt monitoring the port.</param>
    /// <param name="resistorMode">The resistor mode of the port.</param>
    /// <param name="initialDirection">The initial direction of the port.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="pin"/> or <paramref name="channel"/> is <c>null</c>.</exception>
    protected BiDirectionalInterruptPortBase(
        IPin pin,
        IDigitalChannelInfo channel,
        bool initialState,
        InterruptMode interruptMode = InterruptMode.None,
        ResistorMode resistorMode = ResistorMode.Disabled,
        PortDirectionType initialDirection = PortDirectionType.Input)
        : this(pin, channel, initialState, interruptMode, resistorMode, initialDirection, debounceDuration: TimeSpan.Zero, glitchDuration: TimeSpan.Zero, initialOutputType: OutputType.PushPull)
    {
    }

    /// <summary>
    /// Constructor for the BiDirectionalPortBase
    /// </summary>
    /// <param name="pin">The pin associated with the port.</param>
    /// <param name="channel">The channel information for the port.</param>
    /// <param name="initialState">The initial state of the port.</param>
    /// <param name="interruptMode">The type of interrupt monitoring the port.</param>
    /// <param name="resistorMode">The resistor mode of the port.</param>
    /// <param name="initialDirection">The initial direction of the port.</param>
    /// <param name="debounceDuration">The debounce duration of the port.</param>
    /// <param name="glitchDuration">The glitch filter duration of the port.</param>
    /// <param name="initialOutputType">The initial output type of the port.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="pin"/> or <paramref name="channel"/> is <c>null</c>.</exception>
    protected BiDirectionalInterruptPortBase(
        IPin pin,
        IDigitalChannelInfo channel,
        bool initialState,
        InterruptMode interruptMode,
        ResistorMode resistorMode,
        PortDirectionType initialDirection,
        TimeSpan debounceDuration,
        TimeSpan glitchDuration,
        OutputType initialOutputType)
        : base(pin, channel, initialState, resistorMode, initialDirection, initialOutputType)
    {
    }

    /// <summary>
    /// Raises the Changed event and notifies all observers of a state change
    /// </summary>
    /// <param name="changeResult"></param>
    protected void RaiseChangedAndNotify(DigitalPortResult changeResult)
    {
        if (disposed) return;

        Changed?.Invoke(this, changeResult);
        Observers.ForEach(x => x.OnNext(changeResult));
    }

    /// <summary>
    /// Adds a state observer to the port
    /// </summary>
    /// <param name="observer"></param>
    /// <returns></returns>
    public IDisposable Subscribe(IObserver<IChangeResult<DigitalState>> observer)
    {
        if (!Observers.Contains(observer)) Observers.Add(observer);
        var u = new Unsubscriber(Observers, observer);
        _unsubscribers.Add(u);
        return u;
    }

    /// <summary>
    /// Releases allocated port resources 
    /// </summary>
    /// <param name="disposing"></param>
    protected override void Dispose(bool disposing)
    {
        foreach (var u in _unsubscribers)
        {
            u.Dispose();
        }

        base.Dispose(disposing);
    }

    private class Unsubscriber : IDisposable
    {
        private readonly List<IObserver<IChangeResult<DigitalState>>> _observers;
        private readonly IObserver<IChangeResult<DigitalState>> _observer;

        public Unsubscriber(List<IObserver<IChangeResult<DigitalState>>> observers, IObserver<IChangeResult<DigitalState>> observer)
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
