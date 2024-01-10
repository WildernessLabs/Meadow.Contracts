﻿using System;
using System.Text;

namespace Meadow.Peripherals.Sensors.Location.Gnss;

// TODO: Should this be a struct with fields?
/// <summary>
/// Represents a GNSS/GPS position reading.
/// </summary>
public class GnssPositionInfo : IGnssResult
{
    /// <summary>
    /// The first two letters (after the starting delimiter) comprise the
    /// Talker ID, which describes the system in use, for instance "GL" means
    /// that the data came from the GLONASS system. "BD" means BeiDou, etc.
    ///
    /// Default value is "GP".
    /// </summary>
    public string TalkerID { get; set; } = "GP";

    /// <summary>
    /// Retrieves the full name associated with the TalkerID via the
    /// `KnownTalkerIDs` property of the Lookups class.
    /// </summary>
    public string TalkerSystemName
    {
        get
        {
            string name = Lookups.KnownTalkerIDs[TalkerID];
            return (name != null) ? name : "";
        }
    }

    /// <summary>
    /// Time the reading was generated.
    /// </summary>
    public DateTime? TimeOfReading { get; set; }

    /// <summary>
    /// Indicate if the data is valid or not.
    /// </summary>
    public bool Valid { get; set; }

    /// <summary>
    /// Current speed in Knots.
    /// </summary>
    public decimal? SpeedInKnots { get; set; }

    //NOTE: pulled from PositionCourseAndTime
    /// <summary>
    /// Course in degrees (true heading).
    /// </summary>
    public decimal? CourseHeading { get; set; }

    //NOTE: pulled from PositionCourseAndTime
    /// <summary>
    /// Magnetic variation.
    /// </summary>
    public CardinalDirection MagneticVariation { get; set; } = CardinalDirection.Unknown;

    /// <summary>
    /// Global position
    /// </summary>
    public SphericalPositionInfo? Position { get; set; } = new SphericalPositionInfo();

    /// <summary>
    /// Quality of the fix.
    /// </summary>
    public FixType? FixQuality { get; set; } = null; //FixType.Invalid;

    /// <summary>
    /// Number of satellites used to generate the positional information.
    /// </summary>
    public int? NumberOfSatellites { get; set; }

    /// <summary>
    /// Horizontal dilution of position (HDOP).
    /// </summary>
    public decimal? HorizontalDilutionOfPrecision { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="GnssPositionInfo"/> class.
    /// </summary>
    public GnssPositionInfo()
    {
    }

    /// <summary>
    /// Returns a formatted string representing the <see cref="GnssPositionInfo"/> object.
    /// </summary>
    /// <returns>A formatted string representing the <see cref="GnssPositionInfo"/> object.</returns>
    public override string ToString()
    {
        StringBuilder outString = new StringBuilder();

        outString.Append("GnssPositionInfo: {\r\n");
        outString.Append($"\tTalker ID: {TalkerID}, talker name: {TalkerSystemName}\r\n");
        outString.Append($"\tTime of reading: {TimeOfReading?.ToString() ?? "null"}\r\n");
        outString.Append($"\tValid: {Valid}\r\n");
        outString.Append($"\tLatitude: {Position?.Latitude?.ToString() ?? "null"}\r\n");
        outString.Append($"\tLongitude: {Position?.Longitude?.ToString() ?? "null"}\r\n");
        outString.Append($"\tAltitude: {Position?.Altitude?.ToString("f2") ?? "null"}\r\n");
        outString.Append($"\tSpeed in Knots: {SpeedInKnots?.ToString("f2") ?? "null"}\r\n");
        outString.Append($"\tCourse Heading: {CourseHeading?.ToString("f2") ?? "null"}\r\n");
        outString.Append($"\tMagnetic Variation: {MagneticVariation}\r\n");
        outString.Append($"\tNumber of satellites: {NumberOfSatellites?.ToString() ?? "null"}\r\n");
        outString.Append($"\tFix quality: {FixQuality?.ToString() ?? "null"}\r\n");
        outString.Append($"\tHDOP: {HorizontalDilutionOfPrecision?.ToString("f2") ?? "null"}\r\n");
        outString.Append("}");

        return outString.ToString();
    }
}
