using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ExifPhotoReader
{
    public enum SecurityClassification
    {
        Confidential = 'C',
        Restricted = 'R',
        Secret = 'S',
        [Description("Top Secret")]
        TopSecret = 'T',
        Unclassified = 'U'
    }
}
