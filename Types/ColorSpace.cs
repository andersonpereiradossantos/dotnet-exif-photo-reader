using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExifPhotoReader
{
    public enum ColorSpace
    {
        [Description("sRGB")]
        SRGB = 0x1,
        [Description("Adobe RGB")]
        AdobeRGB = 0x2,
        [Description("Wide Gamut RGB")]
        WideGamutRGB = 0xfffd,
        [Description("ICC Profile")]
        ICCProfile = 0xfffe,
        Uncalibrated = 0xffff

    }
}
