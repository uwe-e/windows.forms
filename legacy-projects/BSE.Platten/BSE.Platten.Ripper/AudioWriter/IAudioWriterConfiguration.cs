using System;
using System.Collections.Generic;
using System.Text;

namespace BSE.Platten.Ripper.AudioWriters
{
    interface IAudioWriterConfiguration : BSE.Platten.Common.IOptionsConfiguration
    {
        WaveWriterConfiguration AudioWriterConfiguration { get; set; }
    }
}
