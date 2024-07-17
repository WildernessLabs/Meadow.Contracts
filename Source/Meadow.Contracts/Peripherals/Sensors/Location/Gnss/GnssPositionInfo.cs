using Meadow.Units;
using System;
using System.Text;

namespace Meadow.Peripherals.Sensors.Location.Gnss;

/// <summary>
/// Represents a GNSS/GPS position reading
/// </summary>
public struct GnssPositionInfo : IGnssResult
{
    /// <summary>
    /// The first two letters (after the starting delimiter) comprise the
    /// Talker ID, which describes the system in use, for instance "GL" means
    /// that the data came from the GLONASS system. "BD" means BeiDou, etc.
    ///
    /// Default value is "GP".
    /// </summary>
    public string TalkerID { get; set; }

    /// <summary>
    /// Retrieves the full name associated with the TalkerID via the
    /// `KnownTalkerIDs` property of the Lookups class.
    /// </summary>
    public string TalkerSystemName
    {
        get
        {
            string name = Lookups.KnownTalkerIDs[TalkerID];
            return name ?? "";
        }
    }

    /// <summary>
    /// Time the reading was generated.
    /// </summary>
    public DateTime? TimeOfReading { get; set; }

    /// <summary>
    /// Indicate if the data is valid or not.
    /// </summary>
    public bool IsValid { get; set; }

    /// <summary>
    /// Current speed
    /// </summary>
    public Speed? Speed { get; set; }

    /// <summary>
    /// Course (true heading).
    /// </summary>
    public Azimuth? CourseHeading { get; set; }

    /// <summary>
    /// Magnetic variation.
    /// </summary>
    public CardinalDirection MagneticVariation { get; set; }

    /// <summary>
    /// Global position
    /// </summary>
    public GeographicCoordinate? Position { get; set; }

    /// <summary>
    /// Quality of the fix.
    /// </summary>
    public FixType? FixQuality { get; set; }

    /// <summary>
    /// Number of satellites used to generate the positional information.
    /// </summary>
    public int? NumberOfSatellites { get; set; }

    /// <summary>
    /// Horizontal dilution of position (HDOP).
    /// </summary>
    public decimal? HorizontalDilutionOfPrecision { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GnssPositionInfo"/> struct.
    /// </summary>
    public GnssPositionInfo()
    {
        TalkerID = "GP";
        TimeOfReading = null;
        IsValid = false;
        Speed = null;
        CourseHeading = null;
        MagneticVariation = CardinalDirection.Unknown;
        Position = null;
        FixQuality = null;
        NumberOfSatellites = null;
        HorizontalDilutionOfPrecision = null;
    }

    /// <summary>
    /// Returns a formatted string representing the <see cref="GnssPositionInfo"/> struct.
    /// </summary>
    /// <returns>A formatted string representing the <see cref="GnssPositionInfo"/> struct.</returns>
    public override string ToString()
    {
        StringBuilder outString = new();

        outString.Append("GnssPositionInfo: {\r\n");
        outString.Append($"\tTalker ID: {TalkerID}, talker name: {TalkerSystemName}\r\n");
        outString.Append($"\tTime of reading: {TimeOfReading?.ToString() ?? "null"}\r\n");
        outString.Append($"\tValid: {IsValid}\r\n");
        outString.Append($"\tLatitude: {Position?.Latitude.ToString() ?? "null"}\r\n");
        outString.Append($"\tLongitude: {Position?.Longitude.ToString() ?? "null"}\r\n");
        outString.Append($"\tAltitude: {Position?.Altitude.Meters.ToString("f2") ?? "null"}\r\n");
        outString.Append($"\tSpeed in Knots: {Speed?.MetersPerSecond.ToString("f2") ?? "null"}\r\n");
        outString.Append($"\tCourse Heading: {CourseHeading?.DecimalDegrees.ToString("f2") ?? "null"}\r\n");
        outString.Append($"\tMagnetic Variation: {MagneticVariation}\r\n");
        outString.Append($"\tNumber of satellites: {NumberOfSatellites?.ToString() ?? "null"}\r\n");
        outString.Append($"\tFix quality: {FixQuality?.ToString() ?? "null"}\r\n");
        outString.Append($"\tHDOP: {HorizontalDilutionOfPrecision?.ToString("f2") ?? "null"}\r\n");
        outString.Append("}");

        return outString.ToString();
    }
}