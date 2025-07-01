using Meadow.Modbus;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Meadow.Hardware;

/// <summary>
/// Represents a connector for RS485 (serial) communication
/// </summary>
public abstract class Rs485Connector : IConnector, IPinController
{
    private readonly SerialPortName _serialPortName;
    private ISerialPort? _serialPort;
    private Rs485PinDefinitions? _pins;

    /// <inheritdoc/>
    public string Name { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Rs485Connector"/> class with the specified name and serial port.
    /// </summary>
    /// <param name="name">The name of the RS-485 connector. This value is used to identify the connector.</param>
    /// <param name="serialPortName">The name of the serial port associated with the connector. This parameter cannot be <see langword="null"/>.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="serialPortName"/> is <see langword="null"/>.</exception>
    public Rs485Connector(string name, SerialPortName serialPortName)
    {
        Name = name;
        _serialPortName = serialPortName ?? throw new ArgumentNullException(nameof(serialPortName), "Serial port name cannot be null");
    }

    /// <summary>
    /// The serial port name
    /// </summary>
    public SerialPortName SerialPortName => _serialPortName;

    /// <summary>
    /// Represents the pin definitions for an RS-485 connector, providing access to all pins and their associated
    /// controller.
    /// </summary>
    /// <remarks>This class implements <see cref="IPinDefinitions"/> to expose RS-485 pin definitions and
    /// functionality. It provides access to all pins through the <see cref="AllPins"/> property and allows interaction
    /// with the associated pin controller via the <see cref="Controller"/> property.</remarks>
    public class Rs485PinDefinitions : IPinDefinitions
    {
        private readonly IPin[] _pins = [];

        /// <inheritdoc/>
        public IList<IPin> AllPins => _pins;

        /// <inheritdoc/>
        public IPinController? Controller { get; set; }

        internal Rs485PinDefinitions(Rs485Connector connector)
        {
            Controller = connector;
        }

        /// <inheritdoc/>
        public IEnumerator<IPin> GetEnumerator()
        {
            return ((IEnumerable<IPin>)_pins).GetEnumerator();
        }

        /// <inheritdoc/>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    /// <inheritdoc/>
    public IPinDefinitions Pins => _pins ??= new Rs485PinDefinitions(this);

    /// <summary>
    /// Creates and initializes a serial port with the specified configuration parameters.
    /// </summary>
    /// <remarks>If the serial port is already open, the method ensures that the baud rate matches the
    /// specified value. Otherwise, a new serial port is created and initialized with the provided parameters.</remarks>
    /// <param name="baudRate">The baud rate for the serial port communication. Defaults to 9600.</param>
    /// <param name="dataBits">The number of data bits per byte in the communication. Defaults to 8.</param>
    /// <param name="parity">The parity-checking protocol to use for the communication. Defaults to <see cref="Parity.None"/>.</param>
    /// <param name="stopBits">The number of stop bits to use in the communication. Defaults to <see cref="StopBits.One"/>.</param>
    /// <param name="readBufferSize">The size, in bytes, of the buffer used for reading data from the serial port. Defaults to 1024.</param>
    /// <returns>An instance of <see cref="ISerialPort"/> representing the configured serial port.</returns>
    /// <exception cref="ArgumentException">Thrown if the serial port is already open with a different baud rate.</exception>
    public ISerialPort CreateSerialPort(int baudRate = 9600, int dataBits = 8, Parity parity = Parity.None, StopBits stopBits = StopBits.One, int readBufferSize = 1024)
    {
        if (_serialPort == null)
        {
            _serialPort = _serialPortName.CreateSerialPort(baudRate, dataBits, parity, stopBits, readBufferSize);
        }
        else if (_serialPort.BaudRate != baudRate)
        {
            throw new ArgumentException($"Port is already open at {_serialPort.BaudRate}");
        }

        return _serialPort;

    }

    /// <summary>
    /// Creates a Modbus RTU client configured with the specified serial communication parameters.
    /// </summary>
    /// <remarks>Use this method to create a client for Modbus RTU communication over a serial connection.
    /// Ensure that the specified parameters match the configuration of the Modbus device you are communicating
    /// with.</remarks>
    /// <param name="baudRate">The baud rate for the serial communication. Defaults to 19200. Must be a positive integer.</param>
    /// <param name="dataBits">The number of data bits per byte in the communication. Defaults to 8. Typical values are 7 or 8.</param>
    /// <param name="parity">The parity-checking protocol to use for error detection. Defaults to <see cref="Parity.None"/>.</param>
    /// <param name="stopBits">The number of stop bits to use in the communication. Defaults to <see cref="StopBits.One"/>.</param>
    /// <returns>An instance of <see cref="IModbusBusClient"/> configured for Modbus RTU communication.</returns>
    public abstract IModbusBusClient CreateModbusBusRtuClient(int baudRate = 19200, int dataBits = 8, Parity parity = Parity.None, StopBits stopBits = StopBits.One);

    /// <summary>
    /// Creates a Modbus RTU server instance configured with the specified serial communication parameters.
    /// </summary>
    /// <remarks>The returned server instance can be used to handle Modbus RTU requests over a serial
    /// connection. Ensure that the specified communication parameters match the configuration of the connected Modbus
    /// devices.</remarks>
    /// <param name="baudRate">The baud rate for the serial communication. Defaults to 19200. Must be a positive integer.</param>
    /// <param name="dataBits">The number of data bits per byte in the communication. Defaults to 8. Valid values are typically 7 or 8.</param>
    /// <param name="parity">The parity checking mode for the communication. Defaults to <see cref="Parity.None"/>.</param>
    /// <param name="stopBits">The number of stop bits used in the communication. Defaults to <see cref="StopBits.One"/>.</param>
    /// <returns>An instance of <see cref="IModbusServer"/> configured for Modbus RTU communication.</returns>
    public abstract IModbusServer CreateModbusBusRtuServer(int baudRate = 19200, int dataBits = 8, Parity parity = Parity.None, StopBits stopBits = StopBits.One);
}
