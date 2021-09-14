using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExifPhotoReader
{
    public enum GainControl
    {
        None = 0,
        [Description("Low Gain Up")]
        LowGainUp = 1,
        [Description("High Gain Up")]
        HighGainUp = 2,
        [Description("Low Gain Down")]
        LowGainDown = 3,
        [Description("High Gain Down")]
        HighGainDown = 4
    }
}
