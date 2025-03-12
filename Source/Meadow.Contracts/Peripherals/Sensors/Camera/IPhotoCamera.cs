using System.Threading.Tasks;

namespace Meadow.Peripherals.Sensors.Cameras;

/// <summary>
/// Interface for still photo camera sensors
/// </summary>
public interface IPhotoCamera
{
    /// <summary>
    /// Capture a new image/photo
    /// </summary>
    /// <returns>the picture data as a byte array</returns>
    public Task<byte[]> CapturePhoto();
}