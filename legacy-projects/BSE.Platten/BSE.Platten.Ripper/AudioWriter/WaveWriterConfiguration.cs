using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Security.Permissions;
using System.Globalization;
using BSE.Platten.Ripper.Properties;

namespace BSE.Platten.Ripper.AudioWriters
{
    [Serializable]
    public class WaveWriterConfiguration : ISerializable
    {
        #region Properties

        public WaveFormat WaveFormat
        {
            get;
            set;
        }

        #endregion

        #region MethodsPublic

        public WaveWriterConfiguration(WaveFormat waveFormat)
        {
            if (waveFormat == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,
                    "waveFormat"));
            }
            this.WaveFormat = new WaveFormat(waveFormat.SamplesPerSec, waveFormat.BitsPerSample, waveFormat.Channels);
        }

        public WaveWriterConfiguration()
            : this(new WaveFormat(44100, 16, 2))
        {
        }

        #region ISerializable
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,
                    "info"));
            }
            info.AddValue("Format.Rate", this.WaveFormat.SamplesPerSec);
            info.AddValue("Format.Bits", this.WaveFormat.BitsPerSample);
            info.AddValue("Format.Channels", this.WaveFormat.Channels);
        }

        #endregion

        #endregion

        #region MethodsProtected

        protected WaveWriterConfiguration(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,
                    "info"));
            }
            int rate = info.GetInt32("Format.Rate");
            int bits = info.GetInt32("Format.Bits");
            int channels = info.GetInt32("Format.Channels");
            this.WaveFormat = new WaveFormat(rate, bits, channels);
        }

        #endregion
    }
}
