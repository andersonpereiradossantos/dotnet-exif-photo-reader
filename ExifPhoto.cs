using System;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace ExifPhotoReader
{
    public class ExifPhoto
    {
        public static ExifImageProperties GetExifDataPhoto(string path)
        {
            Image file = new Bitmap(path);

            PropertyItem[] propItems = file.PropertyItems;

            ExifImageProperties exifProperties = new ExifImageProperties();

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

            foreach (PropertyItem item in propItems)
            {
                Convert(item, exifProperties);
            }

            return exifProperties;
        }

        private static ExifImageProperties Convert(PropertyItem property, ExifImageProperties exifProperties)
        {
            string tagId = $"0x{property.Id.ToString("x").PadLeft(4, '0')}";

            ASCIIEncoding encoding = new ASCIIEncoding();
            string propriedade = encoding.GetString(property.Value);

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
                    exifProperties.Orientation = (OrientationEnum)Enum.ToObject(typeof(OrientationEnum), BitConverter.ToInt16(property.Value, 0));
                    break;
                case "0x011a":
                    exifProperties.XResolution = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x011b":
                    exifProperties.YResolution = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x0128":
                    exifProperties.ResolutionUnit = BitConverter.ToInt16(property.Value, 0);
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
                    exifProperties.YCbCrPositioning = BitConverter.ToInt16(property.Value, 0);
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
                    exifProperties.FNumber = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x8822":
                    exifProperties.ExposureProgram = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x8827":
                    exifProperties.ISOSpeedRatings = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x9000":
                    exifProperties.ExifVersion = encoding.GetString(property.Value);
                    break;
                case "0x9003":
                    exifProperties.DateTimeOriginal = DateTime.ParseExact(encoding.GetString(property.Value), "yyyy:MM:dd HH:mm:ss\0", System.Globalization.CultureInfo.InvariantCulture); ;
                    break;
                case "0x9004":
                    exifProperties.DateTimeDigitized = DateTime.ParseExact(encoding.GetString(property.Value), "yyyy:MM:dd HH:mm:ss\0", System.Globalization.CultureInfo.InvariantCulture); ;
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
                    exifProperties.ApertureValue = BitConverter.ToDouble(property.Value, 0);
                    break;
                case "0x9203":
                    exifProperties.BrightnessValue = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x9204":
                    exifProperties.ExposureBiasValue = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x9205":
                    exifProperties.MaxApertureValue = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x9206":
                    exifProperties.SubjectDistance = BitConverter.ToInt32(property.Value, 0);
                    break;
                case "0x9207":
                    exifProperties.MeteringMode = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x9208":
                    exifProperties.LightSource = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x9209":
                    exifProperties.Flash = BitConverter.ToInt16(property.Value, 0);
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
                    exifProperties.ColorSpace = BitConverter.ToInt16(property.Value, 0);
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
                    exifProperties.FocalPlaneResolutionUnit = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0xa217":
                    exifProperties.SensingMethod = BitConverter.ToInt16(property.Value, 0);
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
                    exifProperties.Compression = BitConverter.ToInt16(property.Value, 0);
                    break;
                case "0x0106":
                    exifProperties.PhotometricInterpretation = BitConverter.ToInt16(property.Value, 0);
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
                    exifProperties.PlanarConfiguration = BitConverter.ToInt16(property.Value, 0);
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
                    exifProperties.Predictor = BitConverter.ToInt16(property.Value, 0);
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
                case "0x8825":
                    exifProperties.GPSInfo = BitConverter.ToInt64(property.Value, 0);
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
                    exifProperties.SecurityClassification = encoding.GetString(property.Value);
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
                default:
                    break;
            }

            return exifProperties;
        }
    }
}
