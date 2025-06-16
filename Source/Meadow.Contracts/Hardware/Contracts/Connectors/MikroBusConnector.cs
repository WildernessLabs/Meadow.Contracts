using Meadow.Units;
using System;
using static Meadow.Hardware.MikroBusConnector;

namespace Meadow.Hardware;
/// <summary>
/// Represents a connector for MikroBus devices
/// </summary>
public partial class MikroBusConnector : Connector<MikroBusPinDefinitions>
{
    private readonly SerialPortName? _serialPortName;
    private readonly I2cBusMapping _i2cBusMapping;
    private readonly SpiBusMapping _spiBusMapping;
    private ISpiBus? _spi;
    private II2cBus? _i2c;

    /// <summary>
    /// The serial port name
    /// </summary>
    public SerialPortName SerialPortName => _serialPortName ?? throw new NotSupportedException("This connector does not have serial port support");

    /// <summary>
    /// The set of MikroBus pin names
    /// </summary>
    public static class PinNames
    {
        /// <summary>
        /// Pin AN
        /// </summary>
        public const string AN = "AN";
        /// <summary>
        /// Pin RST
        /// </summary>
        public const string RST = "RST";
        /// <summary>
        /// Pin CS
        /// </summary>
        public const string CS = "CS";
        /// <summary>
        /// Pin SCK
        /// </summary>
        public const string SCK = "SCK";
        /// <summary>
        /// Pin CIPO
        /// </summary>
        public const string CIPO = "CIPO";
        /// <summary>
        /// Pin COPI
        /// </summary>
        public const string COPI = "COPI";
        /// <summary>
        /// Pin PWM
        /// </summary>
        public const string PWM = "PWM";
        /// <summary>
        /// Pin INT
        /// </summary>
        public const string INT = "INT";
        /// <summary>
        /// Pin RX
        /// </summary>
        public const string RX = "RX";
        /// <summary>
        /// Pin TX
        /// </summary>
        public const string TX = "TX";
        /// <summary>
        /// Pin SCL
        /// </summary>
        public const string SCL = "SCL";
        /// <summary>
        /// Pin SDA
        /// </summary>
        public const string SDA = "SDA";
    }

    /// <summary>
    /// Creates a MikroBusConnector
    /// </summary>
    /// <param name="name">The connector name</param>
    /// <param name="mapping">The mappings to the host controller</param>
    /// <param name="hostSerialPort">The mapping for the connector's serial port</param>
    /// <param name="i2CBusMapping">The mapping for the connector's I2C bus</param>
    /// <param name="spiBusMapping">The mapping for the connector's SPI bus</param>
    public MikroBusConnector(string name,
        PinMapping mapping,
        SerialPortName? hostSerialPort,
        I2cBusMapping i2CBusMapping,
        SpiBusMapping spiBusMapping)
        : base(name, new MikroBusPinDefinitions(mapping))
    {
        _serialPortName = hostSerialPort;
        _i2cBusMapping = i2CBusMapping;
        _spiBusMapping = spiBusMapping;
    }

    /// <summary>
    /// Creates a serial port on the connector
    /// </summary>
    /// <param name="baudRate">The speed, in bits per second, of the serial port.</param>
    /// <param name="parity">The `Parity` enum describing what type of cyclic-redundancy-check (CRC) bit, if any, should be expected in the serial message frame. Default is `Parity.None`.</param>
    /// <param name="dataBits">The number of data bits expected in the serial message frame. Default is 8.</param>
    /// <param name="stopBits">The `StopBits` describing how many bits should be expected at the end of every character in the serial message frame. Default is `StopBits.One`.</param>
    /// <param name="readBufferSize">The size, in bytes, of the read buffer. Default is 1024.</param>
    public ISerialPort CreateSerialPort(int baudRate = 9600, int dataBits = 8, Parity parity = Parity.None, StopBits stopBits = StopBits.One, int readBufferSize = 1024)
    {
        return SerialPortName.CreateSerialPort(baudRate, dataBits, parity, stopBits, readBufferSize);
    }

    /// <summary>
    /// Creates an <see cref="ISerialMessagePort"/> directly from a <see cref="SerialPortName"/> using the current <see cref="IMeadowDevice"/>
    /// </summary>
    /// <param name="suffixDelimiter"></param>
    /// <param name="preserveDelimiter"></param>
    /// <param name="baudRate">The speed, in bits per second, of the serial port.</param>
    /// <param name="parity">The `Parity` enum describing what type of cyclic-redundancy-check (CRC) bit, if any, should be expected in the serial message frame. Default is `Parity.None`.</param>
    /// <param name="dataBits">The number of data bits expected in the serial message frame. Default is 8.</param>
    /// <param name="stopBits">The `StopBits` describing how many bits should be expected at the end of every character in the serial message frame. Default is `StopBits.One`.</param>
    /// <param name="readBufferSize">The size, in bytes, of the read buffer. Default is 1024.</param>
    public ISerialMessagePort CreateSerialMessagePort(
        byte[] suffixDelimiter,
        bool preserveDelimiter,
        int baudRate = 9600,
        int dataBits = 8,
        Parity parity = Parity.None,
        StopBits stopBits = StopBits.One,
        int readBufferSize = 512)
    {
        return SerialPortName.CreateSerialMessagePort(suffixDelimiter, preserveDelimiter, baudRate, dataBits, parity, stopBits, readBufferSize)!;
    }

    /// <summary>
    /// Creates an <see cref="ISerialMessagePort"/> directly from a <see cref="SerialPortName"/> using the current <see cref="IMeadowDevice"/>
    /// </summary>
    /// <param name="prefixDelimiter"></param>
    /// <param name="preserveDelimiter"></param>
    /// <param name="messageLength"></param>
    /// <param name="baudRate">The speed, in bits per second, of the serial port.</param>
    /// <param name="parity">The `Parity` enum describing what type of cyclic-redundancy-check (CRC) bit, if any, should be expected in the serial message frame. Default is `Parity.None`.</param>
    /// <param name="dataBits">The number of data bits expected in the serial message frame. Default is 8.</param>
    /// <param name="stopBits">The `StopBits` describing how many bits should be expected at the end of every character in the serial message frame. Default is `StopBits.One`.</param>
    /// <param name="readBufferSize">The size, in bytes, of the read buffer. Default is 1024.</param>
    public ISerialMessagePort CreateSerialMessagePort(
        byte[] prefixDelimiter,
        bool preserveDelimiter,
        int messageLength,
        int baudRate = 9600,
        int dataBits = 8,
        Parity parity = Parity.None,
        StopBits stopBits = StopBits.One,
        int readBufferSize = 512)
    {
        return SerialPortName.CreateSerialMessagePort(prefixDelimiter, preserveDelimiter, messageLength, baudRate, dataBits, parity, stopBits, readBufferSize)!;
    }

    /// <summary>
    /// Gets the connector's I2C bus
    /// </summary>
    public II2cBus I2cBus
        => _i2c ??= _i2cBusMapping.Controller.CreateI2cBus(_i2cBusMapping.BusNumber, I2cBusSpeed.Standard);

    /// <summary>
    /// Gets the connector's SPI bus
    /// </summary>
    public ISpiBus SpiBus
        => _spi ??= _spiBusMapping.Controller.CreateSpiBus(_spiBusMapping.Clock, _spiBusMapping.Copi, _spiBusMapping.Cipo, new Frequency(1, Frequency.UnitType.Megahertz));
}