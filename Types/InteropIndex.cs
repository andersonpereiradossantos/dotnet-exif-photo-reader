using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExifPhotoReader
{
    public enum InteropIndex
    {
        [Description("R03 - DCF option file (Adobe RGB)")]
        R03,
        [Description("R98 - DCF basic file (sRGB)")]
        R98,
        [Description("THM - DCF thumbnail file")]
        THM
    }
}
