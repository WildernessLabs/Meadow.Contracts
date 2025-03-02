namespace Meadow.Hardware;

/// <summary>
/// Contract for devices that expose `ISpiBus(es)`.
/// </summary>
public interface ISpiController : IDigitalOutputController
{
    /// <summary>
    /// The default SPI Bus speed, in kHz, used when speed parameters are not provided
    /// </summary>
    public static Units.Frequency DefaultSpiBusSpeed = new Units.Frequency(375, Units.Frequency.UnitType.Kilohertz);

    /// <summary>
    /// Creates a SPI bus instance for the requested control pins and clock configuration
    /// </summary>
    /// <param name="clock">The IPin instance to use as the bus clock</param>
    /// <param name="copi">The IPin instance to use for data transmit (controller out/peripheral in)</param>
    /// <param name="cipo">The IPin instance to use for data receive (controller in/peripheral out)</param>
    /// <param name="config">The bus clock configuration parameters</param>
    /// <returns>An instance of an <see cref="ISpiBus"/></returns>
    public ISpiBus CreateSpiBus(
        IPin clock,
        IPin copi,
        IPin cipo,
        SpiClockConfiguration config
    );

    /// <summary>
    /// Creates a SPI bus instance for the requested control pins and bus speed
    /// </summary>
    /// <param name="clock">The IPin instance to use as the bus clock</param>
    /// <param name="copi">The IPin instance to use for data transmit (controller out/peripheral in)</param>
    /// <param name="cipo">The IPin instance to use for data receive (controller in/peripheral out)</param>
    /// <param name="speed">The bus speed</param>
    /// <returns>An instance of an <see cref="ISpiBus"/></returns>
    ISpiBus CreateSpiBus(
        IPin clock,
        IPin copi,
        IPin cipo,
        Units.Frequency speed
    );

    /// <summary>
    /// Creates a SPI bus instance for the requested bus number and bus speed
    /// </summary>
    /// <param name="speed">The bus speed</param>
    /// <param name="busNumber">The bus number</param>
    /// <returns>An instance of an <see cref="ISpiBus"/></returns>
    ISpiBus CreateSpiBus(
        int busNumber,
        Units.Frequency speed
    );
}
