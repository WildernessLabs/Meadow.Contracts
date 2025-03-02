namespace Meadow.Update;

/// <summary>
/// Represents an update message.
/// </summary>
public class UpdateMessage : UpdateInfo
{
    /// <summary>
    /// Gets or sets the ID of the MPak.
    /// </summary>
    public string MpakID
    {
        get => ID;
        set => ID = value;
    }

    /// <summary>
    /// Gets or sets the download URL of the MPak.
    /// </summary>
    public string MpakDownloadUrl { get; set; } = default!;

    /// <summary>
    /// Gets or sets the download URL of the MPak including OS.
    /// </summary>
    public string MpakWithOsDownloadUrl { get; set; } = default!;

    /// <summary>
    /// Target OS Version for the update.
    /// </summary>
    public string OsVersion { get; set; } = default!;
}