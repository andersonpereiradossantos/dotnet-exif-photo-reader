using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExifPhotoReader
{
    public enum SensingMethod
    {
        [Description("Monochrome area")]
        MonochromeArea = 1,
        [Description("One-chip color area")]
        OneChipColorArea = 2,
        [Description("Two-chip color area")]
        TwoChipColorArea = 3,
        [Description("Three-chip color area")]
        ThreeChipColorArea = 4,
        [Description("Color sequential area")]
        ColorSequentialArea = 5,
        [Description("Monochrome linear")]
        MonochromeLinear = 6,
        Trilinear = 7,
        [Description("Color sequential linear")]
        ColorSequentialLinear = 8,

    }
}
