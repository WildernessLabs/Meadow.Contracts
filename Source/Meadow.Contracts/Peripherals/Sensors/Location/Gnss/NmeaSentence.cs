﻿using Meadow.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Meadow.Peripherals.Sensors.Location.Gnss;

/// <summary>
/// Represents a NMEA data sentence typically used in GPS/GNSS systems. 
/// </summary>
/// <remarks>
/// For additional info on NMEA sentences, an excellent reference 
/// can found [here](https://gpsd.gitlab.io/gpsd/NMEA.html).
/// </remarks>
public class NmeaSentence
{
    /// <summary>
    /// The first character in the sentence. Usually `$`, but AIVDM/AIVDO
    /// sentences might start with `!`.
    /// </summary>
    public string StartingDelimiter { get; set; } = "$";

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
            return name ?? "";
        }
    }

    /// <summary>
    /// The prefix, excluding the `$` symbol and first two letters of the
    /// sentence, i.e.: `RMC`.
    /// </summary>
    public string? Prefix { get; set; }

    /// <summary>
    /// A list of strings that represent the data elements within a NMEA
    /// sentence, between the prefix and the checksum data. 
    /// </summary>
    public List<string> DataElements { get; set; } = new List<string>();

    /// <summary>
    /// The checksum data of the data elements. Calculated by `XOR`ing
    /// all of the data elements.
    /// </summary>
    public byte Checksum => ChecksumCalculator.XOR(GetDataString());

    /// <summary>
    /// Returns the NMEA sentence string without the checksum digits.
    /// </summary>
    /// <returns></returns>
    protected string GetDataString()
    {
        return $"{StartingDelimiter}{TalkerID}{Prefix},{String.Join(",", DataElements)}";
    }

    /// <summary>
    /// Returns a fully-expressed NMEA data string, including the prefix,
    /// data elements, and checksum information.
    ///
    /// I.e.: $GPRMC,000049.799,V,,,,,0.00,0.00,060180,,,N*48
    /// </summary>
    /// <returns>A string of the sentence.</returns>
    public override string ToString()
    {
        string data = GetDataString(); //don't want to calculate twice
        return data + "*" + ChecksumCalculator.XOR(data);
    }

    /// <summary>
    /// Creates a new, empty NMEA sentence.
    /// </summary>
    public NmeaSentence() { }

    /// <summary>
    /// Tries to creates a <see cref="NmeaSentence"/> from a string.
    /// </summary>
    /// <param name="sentenceString">A NMEA sentence string.</param>
    /// <param name="sentence">The parsed <see cref="NmeaSentence"/></param>
    /// <returns>True on success, otherwise False</returns>
    public static bool TryParse(string sentenceString, out NmeaSentence? sentence)
    {
        try
        {
            sentence = From(sentenceString);
            return true;
        }
        catch
        {
            sentence = null;
            return false;
        }
    }

    /// <summary>
    /// Creates a <see cref="NmeaSentence"/> from a string. Will parse the prefix, data
    /// elements, and also validate the checksum. If the checksum is invalid,
    /// it will throw an <see cref="ArgumentException"/>, therefore this should be used
    /// in a `try`/`catch` block.
    /// </summary>
    /// <param name="sentence">A NMEA sentence string.</param>
    /// <returns>A `NmeaSentence` class representing with the NMEA
    /// information loaded.</returns>
    public static NmeaSentence From(string sentence)
    {
        NmeaSentence newSentence = new NmeaSentence();

        if (string.IsNullOrWhiteSpace(sentence))
        {
            throw new ArgumentException("Empty sentence. Nothing to parse.");
        }

        var checksumLocation = sentence.LastIndexOf('*');
        if (checksumLocation > 0)
        {
            // extract the data from the sentence
            var checksumString = sentence.Substring(checksumLocation + 1);
            var messageData = sentence.Substring(0, checksumLocation);
            byte parsedChecksum;
            // calculate the checksum (have to remove the first character, the "$")
            byte calculatedChecksum = ChecksumCalculator.XOR(messageData.Substring(1));
            try
            {
                parsedChecksum = Convert.ToByte(checksumString.Trim(), 16);
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Checksum failed to parse, error: {e.Message}");
            }

            //if (DebugMode) {
            //Console.WriteLine($"checksum in NMEA:'{checksumString}'");
            //Console.WriteLine($"parsed checksum:{parsedChecksum:x}");
            //Console.WriteLine($"actualData:{messageData}");
            //Console.WriteLine($"Checksum match? {(calculatedChecksum == parsedChecksum ? "yes" : "no")}");
            //}

            // make sure data is good
            if (calculatedChecksum == parsedChecksum)
            {

                int tagLength = messageData.IndexOf(',') - 1;
                int talkerIDLength = (tagLength == 5) ? 2 : 1;
                int prefixIndex = (talkerIDLength == 2) ? 3 : 2;

                // get the starting delimiter (usually `$`)
                // |
                // $GPRMC,000049.799,V,,,,,0.00,0.00,060180,,,N*48
                newSentence.StartingDelimiter = messageData.Substring(0, 1);
                //Console.WriteLine($"Found starting delimiter:{newSentence.StartingDelimiter}");

                // get the talker ID (can be a single digit, so we check tag length)
                //  ||
                // $GPRMC,000049.799,V,,,,,0.00,0.00,060180,,,N*48
                newSentence.TalkerID = messageData.Substring(1, talkerIDLength);
                //Console.WriteLine($"Found TalkerID:{newSentence.TalkerID}");

                // get the prefix
                //    |||
                // $GPRMC,000049.799,V,,,,,0.00,0.00,060180,,,N*48

                newSentence.Prefix = messageData.Substring(prefixIndex, 3);
                //Console.WriteLine($"Found Prefix:{newSentence.Prefix}");

                // split the sentence data up by commas
                var elements = messageData.Split(',').AsSpan<string>();
                if (elements.Length <= 0)
                {
                    throw new ArgumentException("No data in sentence.");
                }
                // store the data
                newSentence.DataElements.Clear();
                // skip the first element, which is the tag ($GPRMC).
                newSentence.DataElements.AddRange(elements.Slice(1).ToArray().Select(elements => elements.Trim()));
            }
            else
            {
                throw new ArgumentException("Checksum does not match data. Invalid data.");
            }
        }
        else
        {
            throw new ArgumentException("No checksum found. Invalid data.");
        }
        return newSentence;
    }
}
