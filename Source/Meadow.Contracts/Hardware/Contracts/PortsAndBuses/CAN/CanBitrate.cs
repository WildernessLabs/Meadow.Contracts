namespace Meadow.Hardware;

/// <summary>
/// Specifies the bitrate for CAN communication.
/// </summary>
public enum CanBitrate
{
    /// <summary>
    /// 5 kbps CAN bitrate.
    /// </summary>
    Can_5kbps = 5_000,

    /// <summary>
    /// 10 kbps CAN bitrate.
    /// </summary>
    Can_10kbps = 10_000,

    /// <summary>
    /// 20 kbps CAN bitrate.
    /// </summary>
    Can_20kbps = 20_000,

    /// <summary>
    /// 33 kbps CAN bitrate.
    /// </summary>
    Can_33kbps = 33_000,

    /// <summary>
    /// 40 kbps CAN bitrate.
    /// </summary>
    Can_40kbps = 40_000,

    /// <summary>
    /// 47 kbps CAN bitrate.
    /// </summary>
    Can_47kbps = 47_000,

    /// <summary>
    /// 50 kbps CAN bitrate.
    /// </summary>
    Can_50kbps = 50_000,

    /// <summary>
    /// 80 kbps CAN bitrate.
    /// </summary>
    Can_80kbps = 80_000,

    /// <summary>
    /// 83 kbps CAN bitrate.
    /// </summary>
    Can_83kbps = 83_000,

    /// <summary>
    /// 95 kbps CAN bitrate.
    /// </summary>
    Can_95kbps = 95_000,

    /// <summary>
    /// 100 kbps CAN bitrate.
    /// </summary>
    Can_100kbps = 100_000,

    /// <summary>
    /// 125 kbps CAN bitrate.
    /// </summary>
    Can_125kbps = 125_000,

    /// <summary>
    /// 200 kbps CAN bitrate.
    /// </summary>
    Can_200kbps = 200_000,

    /// <summary>
    /// 250 kbps CAN bitrate.
    /// </summary>
    Can_250kbps = 250_000,

    /// <summary>
    /// 500 kbps CAN bitrate.
    /// </summary>
    Can_500kbps = 500_000,

    /// <summary>
    /// 800 kbps CAN bitrate.
    /// </summary>
    Can_800kbps = 800_000,

    /// <summary>
    /// 1 Mbps CAN bitrate.
    /// </summary>
    Can_1Mbps = 1_000_000,

    /// <summary>
    /// Flexible Data Rate
    /// </summary>
    Can_FD = -1,
}
