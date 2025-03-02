using System;

namespace Meadow.Hardware;

/// <summary>
/// Represents an SPI bus.
/// </summary>
public interface ISpiBus
{
    /// <summary>
    /// Gets an array of all supported speeds of the SPI bus.
    /// </summary>
    Units.Frequency[] SupportedSpeeds { get; }

    /// <summary>
    /// Gets the current SPI clock configuration.
    /// </summary>
    SpiClockConfiguration Configuration { get; }

    /// <summary>
    /// Reads data from the SPI bus into the specified buffer.
    /// </summary>
    /// <param name="chipSelect">The chip select port to activate the bus.</param>
    /// <param name="readBuffer">The buffer to read data into.</param>
    /// <param name="csMode">The chip select mode that activates the peripheral.</param>
    void Read(IDigitalOutputPort? chipSelect,
        Span<byte> readBuffer,
        ChipSelectMode csMode = ChipSelectMode.ActiveLow);

    /// <summary>
    /// Writes data to the SPI bus.
    /// </summary>
    /// <param name="chipSelect">The chip select port to activate the peripheral.</param>
    /// <param name="writeBuffer">The buffer containing data to write.</param>
    /// <param name="csMode">The chip select mode that activates the peripheral.</param>
    void Write(
        IDigitalOutputPort? chipSelect,
        Span<byte> writeBuffer,
        ChipSelectMode csMode = ChipSelectMode.ActiveLow);

    /// <summary>
    /// Writes data from the write buffer to a peripheral on the bus while reading return data into the read buffer.
    /// </summary>
    /// <param name="chipSelect">The chip select port to activate the peripheral.</param>
    /// <param name="writeBuffer">The buffer containing data to write.</param>
    /// <param name="readBuffer">The buffer to read returning data into.</param>
    /// <param name="csMode">The chip select mode that activates the peripheral.</param>
    void Exchange(IDigitalOutputPort? chipSelect, Span<byte> writeBuffer, Span<byte> readBuffer, ChipSelectMode csMode = ChipSelectMode.ActiveLow);
}