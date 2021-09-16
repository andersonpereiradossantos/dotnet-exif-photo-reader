using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Text;

namespace ExifPhotoReader.Types
{
    public class GPSInfo
    {
        public short VersionID { get; set; }
        public LatitudeRef LatitudeRef { get; set; }
        public double Latitude { get; set; }
        public LongitudeRef LongitudeRef { get; set; }
        public double Longitude { get; set; }
        public AltitudeRef AltitudeRef { get; set; }
        public float Altitude { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Satellites { get; set; }
        public Status Status { get; set; }
        public string MeasureMode { get; set; }
        public long DOP { get; set; }
        public string SpeedRef { get; set; }
        public long Speed { get; set; }
        public TrackRef TrackRef { get; set; }
        public long Track { get; set; }
        public ImgDirectionRef ImgDirectionRef { get; set; }
        public long ImgDirection { get; set; }
        public string MapDatum { get; set; }
        public string DestLatitudeRef { get; set; }
        public double DestLatitude { get; set; }
        public DestLongitudeRef DestLongitudeRef { get; set; }
        public int DestLongitude { get; set; }
        public DestBearingRef DestBearingRef { get; set; }
        public double DestBearing { get; set; }
        public DestDistanceRef DestDistanceRef { get; set; }
        public double DestDistance { get; set; }
        public string ProcessingMethod { get; set; }
        public string AreaInformation { get; set; }
        public DateTime DateStamp { get; set; }
        public Differential Differential { get; set; }
        public double HPositioningError { get; set; }

        public static double ExifGpsToFloat(string gpsRef, PropertyItem propItem)
        {
            uint degreesNumerator = BitConverter.ToUInt32(propItem.Value, 0);
            uint degreesDenominator = BitConverter.ToUInt32(propItem.Value, 4);
            float degrees = degreesNumerator / (float)degreesDenominator;

            uint minutesNumerator = BitConverter.ToUInt32(propItem.Value, 8);
            uint minutesDenominator = BitConverter.ToUInt32(propItem.Value, 12);
            float minutes = minutesNumerator / (float)minutesDenominator;

            uint secondsNumerator = BitConverter.ToUInt32(propItem.Value, 16);
            uint secondsDenominator = BitConverter.ToUInt32(propItem.Value, 20);
            float seconds = secondsNumerator / (float)secondsDenominator;

            float coorditate = degrees + (minutes / 60f) + (seconds / 3600f);

            if (gpsRef == "South" || gpsRef == "West")
                coorditate = 0 - coorditate;
            return coorditate;
        }

        public static DateTime GetDateTime(PropertyItem propItem, string formatacao)
        {
            DateTime data = new DateTime();

            DateTime.ParseExact(BitConverter.ToInt16(propItem.Value, 0).ToString(), formatacao, System.Globalization.CultureInfo.InvariantCulture);

            return data;
        }
    }

    public enum LatitudeRef
    {
        North = 'N',
        South = 'S'
    }

    public enum LongitudeRef
    {
        East = 'E',
        West = 'W'
    }

    public enum AltitudeRef
    {
        [Description("Above Sea Level")]
        AboveSeaLevel = 0,
        [Description("Below Sea Level")]
        BelowSeaLevel = 1
    }

    public enum Status
    {
        [Description("Measurement Active")]
        MeasurementActive = 'A',
        [Description("Measurement Void")]
        MeasurementVoid = 'V'
    }
    public enum TrackRef
    {
        [Description("Magnetic North")]
        MagneticNorth = 'M',
        [Description("True North")]
        TrueNorth = 'T'
    }    
    public enum ImgDirectionRef
    {
        [Description("Magnetic North")]
        MagneticNorth = 'M',
        [Description("True North")]
        TrueNorth = 'T'
    }

    public enum DestLongitudeRef
    {
        East = 'E',
        West = 'W'
    }
    public enum DestBearingRef
    {
        [Description("Magnetic North")]
        MagneticNorth = 'M',
        [Description("True North")]
        TrueNorth = 'T'
    }
    public enum DestDistanceRef
    {
        Kilometers = 'K',
        Miles = 'M',
        [Description("Nautical Miles")]
        NauticalMiles = 'N'
    }
    public enum Differential
    {
        [Description("No Correction")]
        NoCorrection = 0,
        [Description(" Differential Corrected")]
        DifferentialCorrected = 1
    }
}
