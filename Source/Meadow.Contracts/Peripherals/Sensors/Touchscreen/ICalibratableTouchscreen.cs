using System.Collections.Generic;

namespace Meadow.Hardware;

/// <summary>
/// Represents a touch screen device that can be calibrated
/// </summary>
public interface ICalibratableTouchscreen : ITouchScreen
{
    /// <summary>
    /// Returns <b>true</b> if the touchscreen has been calibrated, otherwise <b>false</b>
    /// </summary>
    public bool IsCalibrated { get; }

    /// <summary>
    /// Sets the calibration data for the touchscreen
    /// </summary>
    /// <param name="data">The calibration points</param>
    public void SetCalibrationData(IEnumerable<CalibrationPoint> data);

    /// <summary>
    /// Tests a set of calibration data for validity
    /// </summary>
    /// <param name="data">A set of calibration points to test</param>
    bool IsCalibrationDataValid(IEnumerable<CalibrationPoint> data);
}
