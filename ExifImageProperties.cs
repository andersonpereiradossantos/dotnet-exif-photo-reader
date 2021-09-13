using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExifPhotoReader
{
    public class ExifImageProperties
    {
        public string ImageDescription { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public OrientationEnum Orientation { get; set; }
        public int XResolution { get; set; }
        public int YResolution { get; set; }
        public ResolutionUnitEnum ResolutionUnit { get; set; }
        public string Software { get; set; }
        public DateTime DateTime { get; set; }
        public int WhitePoint { get; set; }
        public int PrimaryChromaticities { get; set; }
        public int YCbCrCoefficients { get; set; }
        public short YCbCrPositioning { get; set; }
        public int ReferenceBlackWhite { get; set; }
        public string Copyright { get; set; }
        public long ExifOffset { get; set; }
        public int ExposureTime { get; set; }
        public int FNumber { get; set; }
        public ExposureProgramEnum ExposureProgram { get; set; }
        public short ISOSpeedRatings { get; set; }
        public string ExifVersion { get; set; }
        public DateTime DateTimeOriginal { get; set; }
        public DateTime DateTimeDigitized { get; set; }
        public string ComponentConfiguration { get; set; }
        public int CompressedBitsPerPixel { get; set; }
        public int ShutterSpeedValue { get; set; }
        public double ApertureValue { get; set; }
        public int BrightnessValue { get; set; }
        public int ExposureBiasValue { get; set; }
        public int MaxApertureValue { get; set; }
        public int SubjectDistance { get; set; }
        public MeteringModeEnum MeteringMode { get; set; }
        public short LightSource { get; set; }
        public short Flash { get; set; }
        public int FocalLength { get; set; }
        public string MakerNote { get; set; }
        public string UserComment { get; set; }
        public string FlashPixVersion { get; set; }
        public short ColorSpace { get; set; }
        public short ExifImageWidth { get; set; }
        public short ExifImageHeight { get; set; }
        public string RelatedSoundFile { get; set; }
        public long ExifInteroperabilityOffset { get; set; }
        public int FocalPlaneXResolution { get; set; }
        public int FocalPlaneYResolution { get; set; }
        public FocalPlaneResolutionUnitEnum FocalPlaneResolutionUnit { get; set; }
        public SensingMethodEnum SensingMethod { get; set; }
        public string FileSource { get; set; }
        public string SceneType { get; set; }
        public short ImageWidth { get; set; }
        public short ImageLength { get; set; }
        public short BitsPerSample { get; set; }
        public short Compression { get; set; }
        public PhotometricInterpretationEnum PhotometricInterpretation { get; set; }
        public short StripOffsets { get; set; }
        public short SamplesPerPixel { get; set; }
        public short RowsPerStrip { get; set; }
        public short StripByteConunts { get; set; }
        public PlanarConfigurationEnum PlanarConfiguration { get; set; }
        public long JpegIFOffset { get; set; }
        public long JpegIFByteCount { get; set; }
        public short YCbCrSubSampling { get; set; }
        public long NewSubfileType { get; set; }
        public short SubfileType { get; set; }
        public short TransferFunction { get; set; }
        public string Artist { get; set; }
        public PredictorEnum Predictor { get; set; }
        public short TileWidth { get; set; }
        public short TileLength { get; set; }
        public long TileOffsets { get; set; }
        public short TileByteCounts { get; set; }
        public long SubIFDs { get; set; }
        public string JPEGTables { get; set; }
        public short CFARepeatPatternDim { get; set; }
        public byte[] CFAPattern { get; set; }
        public int BatteryLevel { get; set; }
        public long IPTCNAA { get; set; }
        public string InterColorProfile { get; set; }
        public string SpectralSensitivity { get; set; }
        public long GPSInfo { get; set; }
        public string OECF { get; set; }
        public short Interlace { get; set; }
        public short TimeZoneOffset { get; set; }
        public short SelfTimerMode { get; set; }
        public int FlashEnergy { get; set; }
        public string SpatialFrequencyResponse { get; set; }
        public string Noise { get; set; }
        public long ImageNumber { get; set; }
        public SecurityClassificationEnum SecurityClassification { get; set; }
        public string ImageHistory { get; set; }
        public short SubjectLocation { get; set; }
        public int ExposureIndex { get; set; }
        public byte[] TIFFEPStandardID { get; set; }
        public string SubSecTime { get; set; }
        public string SubSecTimeOriginal { get; set; }
        public string SubSecTimeDigitized { get; set; }
        public long SpecialMode { get; set; }
        public short JpegQual { get; set; }
        public short Macro { get; set; }
        public short Unknown { get; set; }
        public int DigiZoom { get; set; }
        public string SoftwareRelease { get; set; }
        public string PictInfo { get; set; }
        public string CameraID { get; set; }
        public long DataDump { get; set; }
    }
}
