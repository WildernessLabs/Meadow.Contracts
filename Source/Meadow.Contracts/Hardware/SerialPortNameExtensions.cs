using Meadow.Hardware;
using System;

namespace Meadow
{
    /// <summary>
    /// Extension methods for the SerialPortName class
    /// </summary>
    public static class SerialPortNameExtensions
    {
        /// <summary>
        /// Creates an <see cref="ISerialPort"/> directly from a <see cref="SerialPortName"/> using the current <see cref="IMeadowDevice"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="baudRate"></param>
        /// <param name="dataBits"></param>
        /// <param name="parity"></param>
        /// <param name="stopBits"></param>
        /// <param name="readBufferSize"></param>
        /// <returns></returns>
        public static ISerialPort CreateSerialPort(
            this SerialPortName name,
            int baudRate = 9600,
            int dataBits = 8,
            Parity parity = Parity.None,
            StopBits stopBits = StopBits.One,
            int readBufferSize = 1024)
        {
            return name.SerialController?.CreateSerialPort(name, baudRate, dataBits, parity, stopBits, readBufferSize)
                ?? throw new Exception($"Port {name} does not have a valid serial controller");
        }

        /// <summary>
        /// Creates an <see cref="ISerialMessagePort"/> directly from a <see cref="SerialPortName"/> using the current <see cref="IMeadowDevice"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="suffixDelimiter"></param>
        /// <param name="preserveDelimiter"></param>
        /// <param name="baudRate"></param>
        /// <param name="dataBits"></param>
        /// <param name="parity"></param>
        /// <param name="stopBits"></param>
        /// <param name="readBufferSize"></param>
        /// <returns></returns>
        public static ISerialMessagePort CreateSerialMessagePort(
            this SerialPortName name,
            byte[] suffixDelimiter,
            bool preserveDelimiter,
            int baudRate = 9600,
            int dataBits = 8,
            Parity parity = Parity.None,
            StopBits stopBits = StopBits.One,
            int readBufferSize = 512)
        {
            return name.SerialMessageController?.CreateSerialMessagePort(name, suffixDelimiter, preserveDelimiter, baudRate, dataBits, parity, stopBits, readBufferSize)
                ?? throw new Exception($"Port {name} does not have a valid serial controller");
        }

        /// <summary>
        /// Creates an <see cref="ISerialMessagePort"/> directly from a <see cref="SerialPortName"/> using the current <see cref="IMeadowDevice"/>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="prefixDelimiter"></param>
        /// <param name="preserveDelimiter"></param>
        /// <param name="messageLength"></param>
        /// <param name="baudRate"></param>
        /// <param name="dataBits"></param>
        /// <param name="parity"></param>
        /// <param name="stopBits"></param>
        /// <param name="readBufferSize"></param>
        /// <returns></returns>
        public static ISerialMessagePort CreateSerialMessagePort(
            this SerialPortName name,
            byte[] prefixDelimiter,
            bool preserveDelimiter,
            int messageLength,
            int baudRate = 9600,
            int dataBits = 8,
            Parity parity = Parity.None,
            StopBits stopBits = StopBits.One,
            int readBufferSize = 512)
        {
            return name.SerialMessageController?.CreateSerialMessagePort(name, prefixDelimiter, preserveDelimiter, messageLength, baudRate, dataBits, parity, stopBits, readBufferSize)
                ?? throw new Exception($"Port {name} does not have a valid serial controller");
        }
    }
}
