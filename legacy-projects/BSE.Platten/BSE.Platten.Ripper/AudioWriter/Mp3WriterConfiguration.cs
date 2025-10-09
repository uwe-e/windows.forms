using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Globalization;
using BSE.Platten.Ripper.Properties;
using BSE.Platten.Ripper.Lame;

namespace BSE.Platten.Ripper.AudioWriters
{
    [Serializable]
    public class MP3WriterConfiguration : WaveWriterConfiguration
    {
		#region Properties

        public BeConfiguration BeConfiguration
        {
            get;
            set;
        }
		
		#endregion

		#region MethodsPublic

        public MP3WriterConfiguration(WaveFormat inFormat)
            : this(inFormat, new BeConfiguration(inFormat))
		{
		}

        public MP3WriterConfiguration(WaveFormat inFormat, BeConfiguration beConfiguration)
            : base(inFormat)
		{
            this.BeConfiguration = beConfiguration;
		}
		
		public MP3WriterConfiguration() : this(new WaveFormat(44100, 16, 2))
		{
		}
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
		public override void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
		{
            if (info == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,
                    "info"));
            }
            base.GetObjectData(info, context);
            info.AddValue("BeConfiguration", this.BeConfiguration, this.BeConfiguration.GetType());
		}
		
		#endregion

		#region MethodsProtected

        protected MP3WriterConfiguration(SerializationInfo info, StreamingContext context)
            : base(info, context)
		{
            if (info == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    CultureInfo.InvariantCulture,
                    Resources.IDS_ArgumentNullException,
                    "info"));
            }
            this.BeConfiguration = (BeConfiguration)info.GetValue("BeConfiguration", typeof(BeConfiguration));
		}	
		
		#endregion
    }
}
