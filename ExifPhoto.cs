using System;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using ExifPhotoReader.Types;

namespace ExifPhotoReader
{
    public class ExifPhoto { 
        static List<string> hex = new List<string>();

        public static ExifImageProperties GetExifDataPhoto(string path)
        {
            Image file = new Bitmap(path);

            PropertyItem[] propItems = file.PropertyItems;

            ExifImageProperties exifProperties = new ExifImageProperties();

            exifProperties.GPSInfo = new GPSInfo();

            foreach (PropertyItem item in propItems)
            {
                Convert(item, exifProperties);
            }

            return exifProperties;
        }

        public static ExifImageProperties GetExifDataPhoto(Image file)
        {
            PropertyItem[] propItems = file.PropertyItems;

            ExifImageProperties exifProperties = new ExifImageProperties();

            exifProperties.GPSInfo = new GPSInfo();

            foreach (PropertyItem item in propItems)
            {
                Convert(item, exifProperties);
            }

            return exifProperties;
        }

        public static List<string> GetExifDataPhotoString(Image file)
        {
            PropertyItem[] propItems = file.PropertyItems;

            ExifImageProperties exifProperties = new ExifImageProperties();

            exifProperties.GPSInfo = new GPSInfo();

            foreach (PropertyItem item in propItems)
            {
                Convert(item, exifProperties);
            }

            return hex;
        }

        private static ExifImageProperties Convert(PropertyItem property, ExifImageProperties exifProperties)
        {
            string tagId = $"0x{property.Id.ToString("x").PadLeft(4, '0')}";
            
            hex.Add(tagId);
            
            ASCIIEncoding encoding = new ASCIIEncoding();

            switch (tagId)
            {
                case "0x010e":
                    exifProperties.ImageDescription = encoding.GetString(property.Value);
                    break;
                case "0x010f":
                    exifProperties.Make = encoding.GetString(property.Value);
                    break;
                case "0x0110":
                    exifProperties.Model = encoding.GetString(property.Value);
                    break;
                case "0x0112":
                    exifProperties.Orientation = (Orientation)Enum.ToObject(typeof(Orientation), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x011a":
                    exifProperties.XResolution = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x011b":
                    exifProperties.YResolution = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x0128":
                    exifProperties.ResolutionUnit = (ResolutionUnit)Enum.ToObject(typeof(ResolutionUnit), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x0131":
                    exifProperties.Software = encoding.GetString(property.Value);
                    break;
                case "0x0132":
                    exifProperties.DateTime = DateTime.ParseExact(encoding.GetString(property.Value), "yyyy:MM:dd HH:mm:ss\0", System.Globalization.CultureInfo.InvariantCulture);
                    break;
                case "0x013e":
                    exifProperties.WhitePoint = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x013f":
                    exifProperties.PrimaryChromaticities = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x0211":
                    exifProperties.YCbCrCoefficients = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x0213":
                    exifProperties.YCbCrPositioning = (YCbCrPositioning)Enum.ToObject(typeof(YCbCrPositioning), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x0214":
                    exifProperties.ReferenceBlackWhite = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x8298":
                    exifProperties.Copyright = encoding.GetString(property.Value);
                    break;
                case "0x8769":
                    exifProperties.ExifOffset = BitConverter.ToInt64(property.Value, 0);
                    break;
                case "0x829a":
                    exifProperties.ExposureTime = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x829d":
                    exifProperties.FNumber = (float)BitConverter.ToInt32(property.Value, 0) / (float)BitConverter.ToInt32(property.Value, 4);
                    break;
                case "0x8822":
                    exifProperties.ExposureProgram = (ExposureProgram)Enum.ToObject(typeof(ExposureProgram), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0xa403":
                    exifProperties.WhiteBalance = (WhiteBalance)Enum.ToObject(typeof(WhiteBalance), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0xa402":
                    exifProperties.ExposureMode = (ExposureMode)Enum.ToObject(typeof(ExposureMode), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x8827":
                    exifProperties.ISOSpeedRatings = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x9000":
                    exifProperties.ExifVersion = encoding.GetString(property.Value);
                    break;
                case "0x9003":
                    exifProperties.DateTimeOriginal = DateTime.ParseExact(encoding.GetString(property.Value), "yyyy:MM:dd HH:mm:ss\0", System.Globalization.CultureInfo.InvariantCulture);
                    break;
                case "0x9004":
                    exifProperties.DateTimeDigitized = DateTime.ParseExact(encoding.GetString(property.Value), "yyyy:MM:dd HH:mm:ss\0", System.Globalization.CultureInfo.InvariantCulture);
                    break;
                case "0x9101":
                    exifProperties.ComponentConfiguration = encoding.GetString(property.Value);
                    break;
                case "0x9102":
                    exifProperties.CompressedBitsPerPixel = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x9201":
                    exifProperties.ShutterSpeedValue = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x9202":
                    exifProperties.ApertureValue = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x9203":
                    exifProperties.BrightnessValue = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x9204":
                    exifProperties.ExposureBiasValue = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x9205":
                    exifProperties.MaxApertureValue = (float)BitConverter.ToInt32(property.Value, 0) / (float)BitConverter.ToInt32(property.Value, 4);
                    break;
                case "0x9206":
                    exifProperties.SubjectDistance = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x9207":
                    exifProperties.MeteringMode = (MeteringMode)Enum.ToObject(typeof(MeteringMode), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x9208":
                    exifProperties.LightSource = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x9209":
                    exifProperties.Flash = (Flash)Enum.ToObject(typeof(Flash), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x920a":
                    exifProperties.FocalLength = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x927c":
                    exifProperties.MakerNote = encoding.GetString(property.Value);
                    break;
                case "0x9286":
                    exifProperties.UserComment = encoding.GetString(property.Value);
                    break;
                case "0xa000":
                    exifProperties.FlashPixVersion = encoding.GetString(property.Value);
                    break;
                case "0xa001":
                    exifProperties.ColorSpace = (ColorSpace)Enum.ToObject(typeof(ColorSpace), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0xa002":
                    exifProperties.ExifImageWidth = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0xa003":
                    exifProperties.ExifImageHeight = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0xa004":
                    exifProperties.RelatedSoundFile = encoding.GetString(property.Value);
                    break;
                case "0xa005":
                    exifProperties.ExifInteroperabilityOffset = BitConverter.ToInt64(property.Value, 0);
                    break;
                case "0xa20e":
                    exifProperties.FocalPlaneXResolution = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0xa20f":
                    exifProperties.FocalPlaneYResolution = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0xa210":
                    exifProperties.FocalPlaneResolutionUnit = (FocalPlaneResolutionUnit)Enum.ToObject(typeof(FocalPlaneResolutionUnit), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0xa217":
                    exifProperties.SensingMethod = (SensingMethod)Enum.ToObject(typeof(SensingMethod), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0xa300":
                    exifProperties.FileSource = encoding.GetString(property.Value);
                    break;
                case "0xa301":
                    exifProperties.SceneType = encoding.GetString(property.Value);
                    break;
                case "0x0100":
                    exifProperties.ImageWidth = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x0101":
                    exifProperties.ImageLength = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x0102":
                    exifProperties.BitsPerSample = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x0103":
                    exifProperties.Compression = (Compression)Enum.ToObject(typeof(Compression), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x0106":
                    exifProperties.PhotometricInterpretation = (PhotometricInterpretation)Enum.ToObject(typeof(PhotometricInterpretation), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x0111":
                    exifProperties.StripOffsets = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x0115":
                    exifProperties.SamplesPerPixel = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x0116":
                    exifProperties.RowsPerStrip = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x0117":
                    exifProperties.StripByteConunts = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x011c":
                    exifProperties.PlanarConfiguration = (PlanarConfiguration)Enum.ToObject(typeof(PlanarConfiguration), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x0212":
                    exifProperties.YCbCrSubSampling = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x00fe":
                    exifProperties.NewSubfileType = BitConverter.ToInt64(property.Value, 0);
                    break;
                case "0x00ff":
                    exifProperties.SubfileType = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x012d":
                    exifProperties.TransferFunction = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x013b":
                    exifProperties.Artist = encoding.GetString(property.Value);
                    break;
                case "0x013d":
                    exifProperties.Predictor = (Predictor)Enum.ToObject(typeof(Predictor), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x0142":
                    exifProperties.TileWidth = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x0143":
                    exifProperties.TileLength = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x0144":
                    exifProperties.TileOffsets = BitConverter.ToInt64(property.Value, 0);
                    break;
                case "0x0145":
                    exifProperties.TileByteCounts = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x014a":
                    exifProperties.SubIFDs = BitConverter.ToInt64(property.Value, 0);
                    break;
                case "0x015b":
                    exifProperties.JPEGTables = encoding.GetString(property.Value);
                    break;
                case "0x828d":
                    exifProperties.CFARepeatPatternDim = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x828e":
                    exifProperties.CFAPattern = property.Value;
                    break;
                case "0x828f":
                    exifProperties.BatteryLevel = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x83bb":
                    exifProperties.IPTCNAA = BitConverter.ToInt64(property.Value, 0);
                    break;
                case "0x8773":
                    exifProperties.InterColorProfile = encoding.GetString(property.Value);
                    break;
                case "0x8824":
                    exifProperties.SpectralSensitivity = encoding.GetString(property.Value);
                    break;
                case "0x0000":
                    exifProperties.GPSInfo.VersionID = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x0001":
                    exifProperties.GPSInfo.LatitudeRef = (LatitudeRef)Enum.ToObject(typeof(LatitudeRef), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x0002":
                    exifProperties.GPSInfo.Latitude = GPSInfo.ExifGpsToFloat(exifProperties.GPSInfo.LatitudeRef.ToString(), property);
                    break;
                case "0x0003":
                    exifProperties.GPSInfo.LongitudeRef = (LongitudeRef)Enum.ToObject(typeof(LongitudeRef), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x0004":
                    exifProperties.GPSInfo.Longitude = GPSInfo.ExifGpsToFloat(exifProperties.GPSInfo.LongitudeRef.ToString(), property);
                    break;
                case "0x0005":
                    //exifProperties.GPSInfo.AltitudeRef = (AltitudeRef)Enum.ToObject(typeof(AltitudeRef), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x0006":
                    exifProperties.GPSInfo.Altitude = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x0007":
                    //exifProperties.GPSInfo.TimeStamp = DateTime.ParseExact($"{BitConverter.ToInt32(property.Value, 0).ToString().PadLeft(2, '0')}:{BitConverter.ToInt32(property.Value, 8).ToString().PadLeft(2, '0')}:{BitConverter.ToInt32(property.Value, 16).ToString().PadLeft(2, '0')}\0", "HH:mm:ss\0", System.Globalization.CultureInfo.InvariantCulture);
                    break;
                case "0x0008":
                    exifProperties.GPSInfo.Satellites = encoding.GetString(property.Value);
                    break;
                case "0x0009":
                    exifProperties.GPSInfo.Status = (Status)Enum.ToObject(typeof(Status), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x000a":
                    exifProperties.GPSInfo.MeasureMode = encoding.GetString(property.Value);
                    break;
                case "0x000b":
                    exifProperties.GPSInfo.DOP = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x000c":
                    exifProperties.GPSInfo.SpeedRef = encoding.GetString(property.Value);
                    break;
                case "0x000d":
                    exifProperties.GPSInfo.Speed = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x000e":
                    exifProperties.GPSInfo.TrackRef = (TrackRef)Enum.ToObject(typeof(TrackRef), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x000f":
                    exifProperties.GPSInfo.Track = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x0010":
                    exifProperties.GPSInfo.ImgDirectionRef = (ImgDirectionRef)Enum.ToObject(typeof(ImgDirectionRef), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x0011":
                    exifProperties.GPSInfo.ImgDirection = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x0012":
                    exifProperties.GPSInfo.MapDatum = encoding.GetString(property.Value);
                    break;
                case "0x0013":
                    exifProperties.GPSInfo.DestLatitudeRef = encoding.GetString(property.Value);
                    break;
                case "0x0014":
                    exifProperties.GPSInfo.DestLatitude = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x0015":
                    exifProperties.GPSInfo.DestLongitudeRef = (DestLongitudeRef)Enum.ToObject(typeof(DestLongitudeRef), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x0016":
                    exifProperties.GPSInfo.DestLongitude = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x0017":
                    exifProperties.GPSInfo.DestBearingRef = (DestBearingRef)Enum.ToObject(typeof(DestBearingRef), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x0018":
                    exifProperties.GPSInfo.DestBearing = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x0019":
                    exifProperties.GPSInfo.DestDistanceRef = (DestDistanceRef)Enum.ToObject(typeof(DestDistanceRef), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x001a":
                    exifProperties.GPSInfo.DestDistance = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x001b":
                    exifProperties.GPSInfo.ProcessingMethod = encoding.GetString(property.Value);
                    break;
                case "0x001c":
                    exifProperties.GPSInfo.AreaInformation = encoding.GetString(property.Value);
                    break;
                case "0x001d":
                    exifProperties.GPSInfo.DateStamp = DateTime.ParseExact(encoding.GetString(property.Value), "yyyy:MM:dd\0", System.Globalization.CultureInfo.InvariantCulture);
                    break;
                case "0x001e":
                    exifProperties.GPSInfo.Differential = (Differential)Enum.ToObject(typeof(Differential), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x001f":
                    exifProperties.GPSInfo.HPositioningError = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x8828":
                    exifProperties.OECF = encoding.GetString(property.Value);
                    break;
                case "0x8829":
                    exifProperties.Interlace = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x882a":
                    exifProperties.TimeZoneOffset = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x882b":
                    exifProperties.SelfTimerMode = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x920b":
                    exifProperties.FlashEnergy = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x920c":
                    exifProperties.SpatialFrequencyResponse = encoding.GetString(property.Value);
                    break;
                case "0x920d":
                    exifProperties.Noise = encoding.GetString(property.Value);
                    break;
                case "0x9211":
                    exifProperties.ImageNumber = BitConverter.ToInt64(property.Value, 0);
                    break;
                case "0x9212":
                    exifProperties.SecurityClassification = (SecurityClassification)Enum.ToObject(typeof(SecurityClassification), encoding.GetString(property.Value));
                    break;
                case "0x9213":
                    exifProperties.ImageHistory = encoding.GetString(property.Value);
                    break;
                case "0x9214":
                    exifProperties.SubjectLocation = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x9215":
                    exifProperties.ExposureIndex = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x9216":
                    exifProperties.TIFFEPStandardID = property.Value;
                    break;
                case "0x9290":
                    exifProperties.SubSecTime = encoding.GetString(property.Value);
                    break;
                case "0x9291":
                    exifProperties.SubSecTimeOriginal = encoding.GetString(property.Value);
                    break;
                case "0x9292":
                    exifProperties.SubSecTimeDigitized = encoding.GetString(property.Value);
                    break;
                case "0xa20b":
                    exifProperties.FlashEnergy = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0xa20c":
                    exifProperties.SpatialFrequencyResponse = encoding.GetString(property.Value);
                    break;
                case "0xa214":
                    exifProperties.SubjectLocation = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0xa215":
                    exifProperties.ExposureIndex = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0xa302":
                    exifProperties.CFAPattern = property.Value;
                    break;
                case "0x0200":
                    exifProperties.SpecialMode = BitConverter.ToInt64(property.Value, 0);
                    break;
                case "0x0201":
                    exifProperties.JpegQual = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x0202":
                    exifProperties.Macro = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x0203":
                    exifProperties.Unknown = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x0204":
                    exifProperties.DigiZoom = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x0207":
                    exifProperties.SoftwareRelease = encoding.GetString(property.Value);
                    break;
                case "0x0208":
                    exifProperties.PictInfo = encoding.GetString(property.Value);
                    break;
                case "0x0209":
                    exifProperties.CameraID = encoding.GetString(property.Value);
                    break;
                case "0x0f00":
                    exifProperties.DataDump = BitConverter.ToInt64(property.Value, 0);
                    break;
                case "0xa404":
                    exifProperties.DigitalZoomRatio = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0xa405":
                    exifProperties.FocalLengthIn35mmFormat = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0xa406":
                    exifProperties.SceneCaptureType = (SceneCaptureType)Enum.ToObject(typeof(SceneCaptureType), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0xa407":
                    exifProperties.GainControl = (GainControl)Enum.ToObject(typeof(GainControl), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0xa408":
                    exifProperties.Contrast = (Contrast)Enum.ToObject(typeof(Contrast), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0xa409":
                    exifProperties.Saturation = (Saturation)Enum.ToObject(typeof(Saturation), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0xa40a":
                    exifProperties.Sharpness = (Sharpness)Enum.ToObject(typeof(Sharpness), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0xa40c":
                    exifProperties.SubjectDistanceRange = (SubjectDistanceRange)Enum.ToObject(typeof(SubjectDistanceRange), BitConverter.ToInt16(property.Value, 0));
                    break;
                default:
                    break;
            }

            return exifProperties;
        }
    }
}
